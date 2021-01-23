    Regex r = new Regex(@".{3}");
    for (int i = 0; i < input.Length; i++)
    {
        Console.WriteLine(r.Match(input, i).Value);
    }
