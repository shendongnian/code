    for (int i = 0; i < hello.Count; i++)
    {
        int x = hello[i];
        Console.WriteLine(x);
        if (x == 1) {
            hello.Add(100);
        }
    }
