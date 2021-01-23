    string input = " aa aaa aaaa bb bbb bbbb cc ccc cccc cccc bbb bb aa ".Trim();
    string[] words = input.Split();
    var grouped = words.Distinct().GroupBy(s => s.Length); //EDITED
    int i = 1;
    foreach (var grouping in grouped)
    {
        string elements = string.Join(", ", grouping.ToArray<string>());
        Console.WriteLine("List {0}: {{{1}}}", i, elements);
        i++;
    }
