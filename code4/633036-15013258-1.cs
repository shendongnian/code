    string[] array = { "RS01", "RS10", "RS32A", "RS102", 
                       "RS80", "RS05A", "RS105A", "RS105B" };
    Array.Sort(array, (s1, s2) =>
        {
            Regex regex = new Regex(@"([a-zA-Z]+)(\d+)([a-zA-Z]*)");
            var match1 = regex.Match(s1);                                        
            var match2 = regex.Match(s2);
            // prefix
            int result = match1.Groups[1].Value.CompareTo(match2.Groups[1].Value);
            if (result != 0)
                return result;
            // number 
            result = Int32.Parse(match1.Groups[2].Value)
                            .CompareTo(Int32.Parse(match2.Groups[2].Value));
            if (result != 0)
                return result;
            // suffix
            return match1.Groups[3].Value.CompareTo(match2.Groups[3].Value);
        });
