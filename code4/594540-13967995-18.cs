    public class ConsoleWrapperStub : IConsoleWrapper
    {
        private IList<ConsoleKey> keyCollection;
        private int keyIndex = 0;
        public ConsoleWrapperStub(IList<ConsoleKey> keyCollection)
        {
            this.keyCollection = keyCollection;
        }
        public string Output = string.Empty;
        public ConsoleKeyInfo ReadKey()
        {
            var result = keyCollection[this.keyIndex];
            keyIndex++;
            return new ConsoleKeyInfo( (char)result ,result ,false ,false ,false);
        }
        public void Write(string data)
        {
            Output += data;
        }
    }
