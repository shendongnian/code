    class PrefixedWriter : TextWriter
    {
        private TextWriter originalOut;
        public PrefixedWriter()
        {
            originalOut = Console.Out;
        }
        public override Encoding Encoding
        {
            get { return new System.Text.ASCIIEncoding(); }
        }
        public override void WriteLine(string message)
        {
            originalOut.WriteLine(String.Format("{0} {1}", DateTime.Now, message));
        }
        public override void Write(string message)
        {
            originalOut.Write(String.Format("{0} {1}", DateTime.Now, message));
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetOut(new PrefixedWriter());
            Console.WriteLine("test 1 2 3");
            Console.ReadKey();
        }
    }
