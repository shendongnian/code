    string line = Console.ReadLine();
    foreach (char c in line)
    {
        string name = c.ToString();
        Alphabets parsed = (Alphabets) Enum.Parse(typeof(Alphabets), name);
        Console.WriteLine((int) parsed);
    }
