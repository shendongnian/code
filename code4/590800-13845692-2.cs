    var data = new Dictionary<String, Int32>();
    while (true)
    {
        Console.Write("student/score: ");
        var input = Console.ReadLine();
        if (String.IsNullOrWhiteSpace(input))
        {
            var parts = input.Split();
            data.Add(parts[0], Int32.Parse(parts[1]));
        }
        else
        {
             break;
        }
    }
    foreach (var entry in data)
    {
        Console.WriteLine("{0}\t{1}", entry.Key, entry.Value);
    }
