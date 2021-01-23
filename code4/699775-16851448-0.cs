    string input = "The White Horse is hungry";
    string[] toTest = new string[]{
        "The White Horse is hungary",
        "The White Horse is not hungry",
        "The White Horse is very hungry",
        "The Horse is hungry",
        "The Horse is hungries",
        "White Horse is hungry",
        "star wars..clone wars",
    };
    string closest = toTest
                        .Select(s => new
                        {
                            Str = s,
                            Distance = s.Distance(input)
                        })
                        .OrderByDescending(x => x.Distance)
                        .First().Str;
---
    public static class StringSimilarity
    {
        public static float Distance(this string s1, string s2)
        {
            var p1 = GetPairs(s1);
            var p2 = GetPairs(s2);
            return (2f * p1.Intersect(p2).Count()) / (p1.Count + p2.Count);
        }
        static List<string> GetPairs(string s)
        {
            if (s == null) return new List<string>();
            if (s.Length < 3) return new List<string>() { s };
            List<string> result = new List<string>();
            for (int i = 0; i < s.Length - 1; i++)
            {
                result.Add(s.Substring(i, 2).ToLower(CultureInfo.InvariantCulture));
            }
            return result;
        }
        public static IEnumerable<string> Tokenize(string input)
        {
            return Regex.Matches(input,@"[\w\d]+?",RegexOptions.Singleline)
                        .Cast<Match>()
                        .Select(m=>m.Value.ToLower(CultureInfo.InvariantCulture));
        }
    }
