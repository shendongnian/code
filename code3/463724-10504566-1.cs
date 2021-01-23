    public class FilteringTextWriter : TextWriter
    {
        private HashSet<char> invalidChars;
        private TextWriter destinationStream;
        public FilteringTextWriter(IEnumerable<char> invalidChars, TextWriter destinationStream)
            : base()
        {
            this.invalidChars = new HashSet<char>(invalidChars);
            this.destinationStream = destinationStream;
        }
        public override void Write(char value)
        {
            if (!invalidChars.Contains(value))
            {
                destinationStream.Write(value);
            }
        }
    }
