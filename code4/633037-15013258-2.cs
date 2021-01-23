    public class RSComparer : IComparer<string>
    {
        private Dictionary<string, RS> entries = new Dictionary<string, RS>();
        public int Compare(string x, string y)
        {
            if (!entries.ContainsKey(x))
                entries.Add(x, new RS(x));
            if (!entries.ContainsKey(y))
                entries.Add(y, new RS(y));
            return entries[x].CompareTo(entries[y]);
        }
        private class RS : IComparable
        {
            public RS(string value)
            {
                Regex regex = new Regex(@"([A-Z]+)(\d+)([A-Z]*)");
                var match = regex.Match(value);
                Prefix = match.Groups[1].Value;
                Number = Int32.Parse(match.Groups[2].Value);
                Suffix = match.Groups[3].Value;
            }
            public string Prefix { get; private set; }
            public int Number { get; private set; }
            public string Suffix { get; private set; }
            public int CompareTo(object obj)
            {
                RS rs = (RS)obj;
                int result = Prefix.CompareTo(rs.Prefix);
                if (result != 0)
                    return result;
                result = Number.CompareTo(rs.Number);
                if (result != null)
                    return result;
                return Suffix.CompareTo(rs.Suffix);
            }
        }
    }
