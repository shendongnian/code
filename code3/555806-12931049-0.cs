    private enum Towns
    {
        Aberdeen,
        Ayr,
        FortWilliam,
        Glasgow,
        ...
    }
    private static IDictionary<Towns, int> GetEdinburgh()
    {
        return new Dictionary
        {
            { Key = Aberdeen, Value = 129 },
            { Key = Ayr, Value = 79 },
            { Key = FortWilliam, Value = 131 },
            { Key = Glasgow, Value = 43 },
            ...
        };
    }
    static void Main(string[] args)
    {
        var closest = this.GetEdinburgh()
            .Where(p => p.Value < 1000)
            .Min(p => p.Value);
        
        Console.WriteLine("{0}, {1}km", closest.Key, closest.Value);
        Console.ReadKey();
    }
