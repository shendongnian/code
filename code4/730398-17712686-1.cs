    public class ConsoleTextWriter: TextWriter
    {
        public override void Write(char value)
        {
            Console.Write(value);
        }
        public override Encoding Encoding
        {
            get { return Encoding.Default; }
        }
    }
