    var s = Stopwatch.StartNew();
    var r = new Regex(string.Join("|", from x in inside select Regex.Escape(x.Key)));
    for (int i = 1; i <= a.PageCount; i++)
    {
        foreach (Match match in r.Matches(a.Pages[i].Text))
        {
            inside[match.Value].Add(i.ToString());
        }
    }
    Console.WriteLine(s.Elapsed);
