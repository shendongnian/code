    internal class FakeStreamWriter : StreamWriter
    {
        public List<string> Writes { get; set; } = new List<string>();
        public FakeStreamWriter() : base(new MemoryStream()) { }
        public override void Write(string value)
        {
            WriteLine(value);
        }
        public override void WriteLine(string value)
        {
            Writes.Add(value);
        }
        public override void Flush()
        {
            
        }
    }
