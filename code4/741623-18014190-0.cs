    static void Main(string[] args)
    {
        var items = new[] {1, 1, 1, 1, 1, 3, 2, 1, 5, 2};
    
        var over = items.Distinct().ToList().Where(i=>items.Where(it => it == i).Count() > 5);
        Console.Read();
    }
