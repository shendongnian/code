    private static void Main(string[] args)
    {
        decimal? x = null;
        decimal? y = null;
        y = 5M;
        decimal? CS$0$0000 = x;
        decimal? CS$0$0001 = y;
        if ((CS$0$0000.GetValueOrDefault() != CS$0$0001.GetValueOrDefault()) || (CS$0$0000.HasValue != CS$0$0001.HasValue))
        {
            Console.WriteLine("true");
        }
        else
        {
            Console.WriteLine("false");
        }
    }
