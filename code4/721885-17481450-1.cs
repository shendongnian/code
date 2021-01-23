    static void Main(string[] args)
    {
        Console.WriteLine(typeof(int).GetRealTypeName());
        Console.WriteLine(typeof(List<string>).GetRealTypeName());
        Console.WriteLine(typeof(long?).GetRealTypeName());
        Console.WriteLine(typeof(Dictionary<int, List<string>>).GetRealTypeName());
        Console.WriteLine(typeof(Func<List<Dictionary<string, object>>, bool>).GetRealTypeName());
    }
