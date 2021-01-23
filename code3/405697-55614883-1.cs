    Whole.Ang[n] = (Math.Pow(Whole.Long[n], 2) + Math.Pow(Whole.Long[n - 1], 2) - Math.Pow(Line1, 2)
                 / (2 * Whole.Long[n] * Whole.Long[n - 1]);
    if (Whole.Ang[n] > Math.PI / 2)
    {
        Whole.Ang[n] = Math.Asin(Math.PI / 2 - Whole.Ang[n]);
        Whole.Ang[n] = Math.Round(Whole.Ang[n] * 180 / Math.PI, 0) * 2;
        Whole.Ang[n] = (90 - Whole.Ang[n] * 2) + Whole.Ang[n];
        Console.WriteLine("第" + (n + 1) + "个角为：" + Whole.Ang[n]);
        continue;
    }
    else
    {
        Whole.Ang[n] = Math.Acos(Whole.Ang[n]);
        Whole.Ang[n] = Math.Round(Whole.Ang[n] * 180 / Math.PI, 0);
        Console.WriteLine("第" + (n + 1) + "个角为：" + Whole.Ang[n]);
        continue;
    }
