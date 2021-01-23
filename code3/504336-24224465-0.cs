    class Config
    {
        public Fizz ObsoleteSetting { get; set; }
        public Bang ReplacementSetting { get; set; }
    }
    enum Fizz { Alpha, Beta, Gamma }
    class Bang
    {
        public string Value { get; set; }
    }
