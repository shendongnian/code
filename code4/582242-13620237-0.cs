    string line = Console.ReadLine();
    foreach (char c in line)
    {
        string name = c.ReadLine();
        Alphabets parsed = (Alphabets) Enum.Parse(typeof(Alphabets), name);
        Console.WriteLine((int) parsed);
    }
