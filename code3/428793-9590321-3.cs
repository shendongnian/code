    public class NullParser : IParser
    {
        public void Parse(string given) { /* do nothing */ }
        // should return true for every non-null string
        public string RequiredPrefix { get { return string.Empty; } }
    }
