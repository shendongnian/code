    static void Main()
    {
        Assert.AreEqual("1, 3, 5, 6, 7, 12, 13, 14", Transform("3, 7, 12-14, 1, 5-6"));
    }
    private static string Transform(string input)
    {
        StringBuilder sb = new StringBuilder();
        foreach(Match m in new Regex(@"(?<start>\d+)(?:-(?<end>\d+))?(?:,|$)\s*").Matches(input)
            .OfType<Match>().OrderBy(m => int.Parse(m.Groups["start"].Value)))
        {
            int start = int.Parse(m.Groups["start"].Value);
            int end = !m.Groups["end"].Success ? start : int.Parse(m.Groups["end"].Value);
            foreach (int val in Enumerable.Range(start, end - start + 1))
                sb.AppendFormat("{0}, ", val);
        }
        if (sb.Length > 0)
            sb.Length = sb.Length - 2;//remove trailing comma+space;
        return sb.ToString();
    }
