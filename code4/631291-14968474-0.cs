    class MySettings
    {
        public int MaxNumLogins { get; set; }
        // specify the value to default to if it's not present in the serialized file...
        [DefaultValue(0)]
        public int CacheTimeoutMinutes { get; set; }
    }
