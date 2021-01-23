    static void Main(string[] args)
    {
        var symbols = GetCurrencySymbols();
        Console.WriteLine("{0}{1:0.00}", symbols["USD"], 1.5M);
        Console.WriteLine("{0}{1:0.00}", symbols["JPY"], 1.5M);
        Console.ReadLine();
    }
    static IDictionary<string, string> GetCurrencySymbols()
    {
        var result = new Dictionary<string, string>();
        foreach (var ci in CultureInfo.GetCultures(CultureTypes.AllCultures))
        {
            try
            {
                var ri = new RegionInfo(ci.Name);
                result[ri.ISOCurrencySymbol] = ri.CurrencySymbol;                    
            }
            catch { }
        }
        return result;
    }
