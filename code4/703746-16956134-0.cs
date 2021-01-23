    public class ClassInOtherThread
    {
        private readonly IConsoleWriter _consoleWriter;
        public ClassInOtherThread(IConsoleWriter consoleWriter)
        {
            this._consoleWriter = consoleWriter;
        }
        public void DoSomething()
        {
            _consoleWriter.Write("something");
        }
    }
    public interface IConsoleWriter
    {
        void Write(string value);
    }
    public class ConsoleWriter : IConsoleWriter
    {
        public void Write(string value)
        {
            // Fix your >  problems in this class
            Console.Write(value);
        }
    }
