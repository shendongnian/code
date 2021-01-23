    var lstNames = new List<string> { "A", "B", "A" };
    var hashset = new HashSet<string>();
    foreach(var name in names)
    {
        if (!hashset.Add(name))
        {
            Console.WriteLine("List contains duplicate values.");
            break;
        }
    }
