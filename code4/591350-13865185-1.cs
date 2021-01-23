    public class Program
    {
        public static void Main(string[] args)
        {
            using (new ConsoleRedirect<DebugTextWriter>())
            {
                Console.WriteLine("Testing testing...");
            }
            Console.WriteLine("Testing testing 2...");
            Console.ReadLine();
        }
    }
    public class ConsoleRedirect<T> : IDisposable
        where T : TextWriter, new()
    {
        private readonly TextWriter _tmpTextWriter;
        public ConsoleRedirect()
        {
            _tmpTextWriter = Console.Out;
            Console.SetOut(new T());
        }
        public void Dispose()
        {
            Console.SetOut(_tmpTextWriter);
        }
    }
    public class DebugTextWriter : TextWriter
    {
        public override void WriteLine(string value)
        {
            Debug.WriteLine(value);
        }
        public override void WriteLine(object value)
        {
            Debug.WriteLine(value);
        }
        public override void WriteLine(string format, params object[] arg)
        {
            Debug.WriteLine(format, arg);
        }
        public override Encoding Encoding
        {
            get { return Encoding.UTF8; }
        }
    }
