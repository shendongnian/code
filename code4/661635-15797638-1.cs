    public struct Version
    {
        private string value;
        private Version(string value)
        {
            this.value = value;
        }
        public static readonly Version Version1 = new Version("Version1");
        public static readonly Version Version2 = new Version("Version2");
        public override string ToString()
        {
            return value;
        }
    }
