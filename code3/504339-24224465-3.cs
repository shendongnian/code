    class Config
    {
        [JsonIgnore]
        public Fizz ObsoleteSetting { get; set; }
        [JsonProperty("ObsoleteSetting")]
        private Fizz ObsoleteSettingAlternateSetter
        {
            // get is intentionally omitted here
            set { ObsoleteSetting = value; }
        }
        public Bang ReplacementSetting { get; set; }
    }
