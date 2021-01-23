    class Config
    {
        public Fizz ObsoleteSetting { get; set; }
        public Bang ReplacementSetting { get; set; }
        public bool ShouldSerializeObsoleteSetting()
        {
            return false;
        }
    }
