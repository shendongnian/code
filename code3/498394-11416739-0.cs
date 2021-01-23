    // put it in a console application
    static void Test()
    {
        Stopwatch sw = new Stopwatch();
        StringBuilder sb = new StringBuilder();
        string strText = "this will become a very long string after my code has done appending it to the stringbuilder ";
        Enumerable.Range(1, 100000).ToList().ForEach(i => sb.Append(strText));
        strText = sb.ToString();
        sw.Start();
        var arr = Regex.Matches(strText, @"\b[A-Za-z-']+\b")
                  .OfType<Match>()
                  .Select(m => m.Groups[0].Value)
                  .ToArray();
        sw.Stop();
        Console.WriteLine("OfType: " + sw.ElapsedMilliseconds.ToString());
        sw.Reset();
        sw.Start();
        var arr2 = Regex.Matches(strText, @"\b[A-Za-z-']+\b")
                  .Cast<Match>()
                  .Select(m => m.Groups[0].Value)
                  .ToArray();
        sw.Stop();
        Console.WriteLine("Cast: " + sw.ElapsedMilliseconds.ToString());
    }
