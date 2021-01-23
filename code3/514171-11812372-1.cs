    [SqlFunction(FillRowMethodName = "FillRow3")]
    public static IEnumerable GetCsv(string csv)
    {
        string[] arr = csv.Split(',');
        return arr.Select((x, i) => Tuple.Create(x, i));
    }
    
    public static void FillRow3(Object obj, out string val, out int index)
    {
        var input = (Tuple<string, int>)obj;
        val = input.Item1;
        index = input.Item2;
    }
