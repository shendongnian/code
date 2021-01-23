        var strTest = new List<string> { "B1", "B2", "B3", "B10" };
        strTest.Sort((s1, s2) => 
        {
            string pattern = "([A-Za-z])([0-9]+)";
            string h1 = Regex.Match(s1, pattern).Groups[1].Value;
            string h2 = Regex.Match(s2, pattern).Groups[1].Value;
            if (h1 != h2)
                return h1.CompareTo(h2);
            string t1 = Regex.Match(s1, pattern).Groups[2].Value;
            string t2 = Regex.Match(s2, pattern).Groups[2].Value;
            return int.Parse(t1).CompareTo(int.Parse(t2));
        });
