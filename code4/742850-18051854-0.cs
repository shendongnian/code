    static void Main(string[] args)
    {
        var input = @"Part error(1) devic[3].data_type(2)
    Escape error(3) device[10].data_type(12)";
        var functions = new Dictionary<Category, Action<string>>()
        {
            { Category.Part, HandlePart},
            { Category.Escape, HandleEscape }
        };
        foreach (var line in input.Split(new [] {Environment.NewLine }, StringSplitOptions.None))
        {
            Category category;
            if(Enum.TryParse<Category>(line.Substring(0, line.IndexOf(' ')), out category) && functions.ContainsKey(category))
                functions[category](line);
        }
    }
    static void HandlePart(string line)
    {
        Console.WriteLine("Part handler call");
    }
    static void HandleEscape(string line)
    {
        Console.WriteLine("Escape handler call");
    }
