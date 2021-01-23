    {
        string s = "01005010050";
        var ls = new List<int>();
        for (int n = 0; n < s.Length - 1; n++)
        {
            if ((int)s[n] == 48 && (int)s[n + 1] != 48) // 48 = Ascii(0)
            {
                s = s.Insert(n + 1, ";");
            }
        }
        ls = s.Split(';').Select(Int32.Parse).ToList();
        for (int n = 1; n < ls.Count(); n++)
        {
            ls[0] += ls[n];
        }
    }
