    class ArgumentMatch {
        public Argument Key;
        public string Value;
        public Argument Unmatched;
    }
    // if you define the constructor
    return new ArgumentMatch(p, "", null);
    // or using object initializer syntax,
    return new ArgumentMatch { Key = p, Value = "" };
