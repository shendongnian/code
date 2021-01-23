    public class SomeClass
    {
        TextWriter _Writer = null;
        public SomeClass(FileStream f) : this(new StreamWriter(f,Encoding.UTF8))
        {
        }
        public SomeClass(TextWriter tw)
        {
            _Writer = tw;
        }
        void WriteString(string s)
        {
            _Writer.Write(s);
        }
    }
