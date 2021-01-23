    string input = " aa aaa aaaa bb bbb bbbb cc ccc cccc cccc bbb bb aa ";
    Dictionary<int, string[]> results = new Dictionary<int, string[]>();
    var grouped = input.Trim().Split().Distinct().GroupBy(s => s.Length)
        .OrderBy(g => g.Key); // or: OrderByDescending(g => g.Key);
    foreach (var grouping in grouped)
    {
        results.Add(grouping.Key, grouping.ToArray());
    }
