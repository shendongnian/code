    [System.AttributeUsage(System.AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public sealed class ConversionAttribute : System.Attribute
    {
        public string DatabaseName { get; set; }
        public bool ReadOnly { get; set; }
        public int ConversionOrder { get; set; }
        public String VersionStart { get; set; }
        public String VersionEnd { get; set; }
    }
