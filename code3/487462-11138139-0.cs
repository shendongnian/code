    foreach (var c in str)
    {
        if (char.IsControl(c))
        {
            Console.WriteLine("Found control character: {0}", (int)c);
        }
    }
