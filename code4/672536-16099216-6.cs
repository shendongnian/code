    for (int x = 0; x < takeinput.Length; x++)
    {
        Console.Clear();
        for(y = 0; y < x; y++)
        {
            Console.SetCursorPosition(0, y + 1);
            Console.WriteLine("{0}: {1}", _answers.Keys[y], _answers.Values[y]);
        }
        Console.SetCursorPosition(0, 0);
        Console.Write(takeinput[x] + ": ");
        var answer = Console.ReadLine();
        _answers.Add(takeinput[x], answer);
    }
