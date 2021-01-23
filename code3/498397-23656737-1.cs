    Stopwatch sw = new Stopwatch();
    StringBuilder sb = new StringBuilder();
    string strText = "this will become a very long string after my code has done appending it to the stringbuilder ";
    Enumerable.Range(1, 100000).ToList().ForEach(i => sb.Append(strText));
    strText = sb.ToString();
    //First two benchmarks
    sw.Start();
    MatchCollection mc = Regex.Matches(strText, @"\b[A-Za-z-']+\b");
    var matches = new string[mc.Count];
    for (int i = 0; i < matches.Length; i++)
    {
        matches[i] = mc[i].ToString();
    }
    sw.Stop();
