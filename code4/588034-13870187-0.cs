    class CountryTuple
    {
        public string Code { get; private set; }
        public string Name { get; private set; }
        public CountryTuple(string code, string name)
        {
            this.Code = code;
            this.Name = name;
        }
    }
