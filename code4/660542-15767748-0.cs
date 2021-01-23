    class SomeRecord : IComparable<SomeRecord> {
        public SomeRecord(string line) {
            string[] fields = line.Split('-');
            Item1 = fields[0];
            Item2 = fields[1];
            Item3 = fields[2];
            Item4 = fields[3];
        }
        public string Item1 { get;set; }
        public string Item2 { get;set; }
        public string Item3 { get;set; }
        public string Item4 { get;set; }
        int IComparable<SomeRecord>.CompareTo(SomeRecord other) {
            // implement your custom logic here, returning -1, 0, or 1
        }
    }
