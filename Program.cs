using System;
using System.Collections.Generic;

public class PhanSo
{
    public int TuSo { get; set; }
    public int MauSo { get; set; }

    public PhanSo() { }

    public PhanSo(int tu, int mau)
    {
        TuSo = tu;
        MauSo = mau != 0 ? mau : 1;
    }

    public void Nhap()
    {
        Console.Write("- Nhập tử số: ");
        TuSo = int.Parse(Console.ReadLine());
        Console.Write("- Nhập mẫu số: ");
        MauSo = int.Parse(Console.ReadLine());
        if (MauSo == 0)
        {
            Console.WriteLine("Mẫu số không thể là 0. Đặt mẫu số = 1.");
            MauSo = 1;
        }
    }

    public static PhanSo Cong(PhanSo a, PhanSo b)
    {
        int tu = a.TuSo * b.MauSo + b.TuSo * a.MauSo;
        int mau = a.MauSo * b.MauSo;
        return RutGon(new PhanSo(tu, mau));
    }

    public static PhanSo RutGon(PhanSo ps)
    {
        int ucln = UCLN(Math.Abs(ps.TuSo), Math.Abs(ps.MauSo));
        ps.TuSo /= ucln;
        ps.MauSo /= ucln;
        return ps;
    }

    public static int UCLN(int a, int b)
    {
        while (b != 0)
        {
            int temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }

    public override string ToString() => $"{TuSo}/{MauSo}";
}

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        List<PhanSo> danhSach = new List<PhanSo>();
        Console.Write("Nhập số lượng phân số: ");
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"Phân số thứ {i + 1}:");
            PhanSo ps = new PhanSo();
            ps.Nhap();
            danhSach.Add(ps);
        }

        PhanSo tong = new PhanSo(0, 1);
        foreach (var ps in danhSach)
        {
            tong = PhanSo.Cong(tong, ps);
        }

        Console.WriteLine($"Tổng các phân số là: {tong}");
    }
}