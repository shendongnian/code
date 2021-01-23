    class LocalStringInterner
    {
        private Dictionary<string, string> _strings = new Dictionary<string, string>();
        public string Intern(string str)
        {
            string interned;
            if (_strings.TryGetValue(str, out interned))
                return interned;
            _strings.Add(str, str);
            return str;
        }
    }
