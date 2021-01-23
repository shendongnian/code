    string input = " aa aaa aaaa bb bbb bbbb cc ccc cccc cccc bbb bb aa ";
    List<string[]> results = new List<string[]>();
    var grouped = input.Trim().Split().Distinct().GroupBy(s => s.Length); //EDITED
    foreach (var grouping in grouped)
    {
        results.Add(grouping.ToArray());
    }
