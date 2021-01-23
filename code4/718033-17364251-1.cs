    Regex r = new Regex(@".{3}");
    for (int i = 0; i < input.Length; i++)
    {
        Match m = r.Match(input, i);
        if(m.Success)
            Console.WriteLine(m.Value);
    }
