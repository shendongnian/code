        string keyword = "internet bandwidth";
        string input = "Test your Internet connection bandwidth. Test your Internet connection bandwidth.";
        Regex r = new Regex(keyword.Replace(' ', '|'), RegexOptions.IgnoreCase);
        MatchCollection mc = r.Matches(input);
        List<string> res = new List<string>();
        for (int i = 0; i < mc.Count;i++ )
        {
            res.Add(mc[i].Value);
        }
        if (res.Distinct().Count() == keyword.Split(' ').Length)
        {
            //Do something
        }
