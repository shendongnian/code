    public class ConsoleWriter : IWriter
    {
        public void Write(string s) {
             Console.WriteLine(s);
        }
    }
    public class MemoryWriter : IWriter
    {
        public void Write(string s) {
            // code to create a memory object and write to it
        }
    }
