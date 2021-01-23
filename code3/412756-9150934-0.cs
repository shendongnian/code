    static void Main(string[] args)
    {
        UInt64 EsnDec = 2161133276;
        Console.WriteLine(EsnDec);
        //Convert to String
        string Esn = EsnDec.ToString();
        Esn = "80" + Esn.Substring(Esn.Length - 6);
        //Convert back to UInt64
        EsnDec = Convert.ToUInt64(Esn);
        Console.WriteLine(EsnDec);
        Console.ReadKey();
    }
