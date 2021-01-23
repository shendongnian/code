    while (true)
    {
        Console.Write("student/score: ");
        var input = Console.ReadLine();
        if (String.IsNullOrWhiteSpace(input))
        {
            var parts = input.Split();
            names.Add(parts[0]);
            scores.Add(Int32.Parse(parts[1]);
        }
        else
        {
             break;
        }
    }
