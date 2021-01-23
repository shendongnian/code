    static void Main(string[] args)
    {
        var names = new List<string> { "Homer", "Marge", "Lisa" };
        Show(names);
        names.Insert(1, "Bart");
        Console.WriteLine("Inserted Bart at 1");
        Show(names);
        names.RemoveAt(0);
        Console.WriteLine("Removed Homer");
        Show(names);
    }
    private static void Show(List<string> names)
    {
        Console.WriteLine("Names");
        for (int i = 0; i < names.Count; i++)
            Console.WriteLine("\t{0}: {1}", i, names[i]);
    }
