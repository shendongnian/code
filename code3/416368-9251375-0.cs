    class StringComparer : IComparer<string>
    {
        private static Regex _regex = new Regex(@"\d+$", RegexOptions.Compiled);
        public int Compare(string a, string b)
        {
            long numberA = Int64.Parse(_regex.Match(a).Value);
            long numberB = Int64.Parse(_regex.Match(b).Value);
            return numberA.CompareTo(numberB);
        }
    }
