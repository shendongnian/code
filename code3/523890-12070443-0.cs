    public static string *GetExtension*(string cale) //GetExtension is an error
    {
        string fisier, extensie;
        cale = @"D:\dir1\dir2\";
        fisier = @"D:\dir1\dir2\fisier.txt";
        extensie = Path.GetExtension(fisier);
        System.Console.WriteLine("Extensie: {0} returneaza {1}", fisier, extensie);
        extensie = Path.GetExtension(cale);
        System.Console.WriteLine("Extensie: {0} returneaza {1}", fisier, extensie);
        return extensie; //<----------------
    }
