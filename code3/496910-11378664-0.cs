    string input = "aa aaa aaaa bb bbb bbbb cc ccc cccc";
    string[] words = input.Split();
    var grouped = words.GroupBy(s => s.Length);
    int i = 1;
    foreach (var grouping in grouped)
    {
        string elements = string.Join(", ", grouping.ToArray<string>());
        Console.WriteLine("List {0}: {{{1}}}", i, elements);
        i++;
    }
