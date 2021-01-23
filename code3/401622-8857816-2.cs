    class Name : Tuple<string, string>
    {
        public Name(string first, string last)
            : base(first, last)
        {
        }
    
        public static implicit operator string[](Name name)
        {
            return new string[] { name.Item1, name.Item2 };
        }
    }
