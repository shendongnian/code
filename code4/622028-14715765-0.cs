    public struct CsvRowFormat
    {
        public string Value { get; private set; }
        private CsvRowFormat(string value) : this()
        {
            Value = value;
        }
        public static BeginningOfFile { get { return new CsvRowFormat("01"); } }
        public static School { get { return new CsvRowFormat("02"); } }
        public static Student { get { return new CsvRowFormat("03"); } }
        public static EndOfFile { get { return new CsvRowFormat("04"); } }
    }
