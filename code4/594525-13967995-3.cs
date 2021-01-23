    public class ConsoleWrapperStub : IConsoleWrapper
    {
        private IList<ConsoleKeyInfo> keyCollection;
        private int keyIndex = 0;
    
        public ConsoleWrapperStub(IList<ConsoleKeyInfo> keyCollection)
        {
            this.keyCollection = keyCollection;
        }
    
        public string Output = string.Empty;
    
        public ConsoleKeyInfo ReadKey()
        {
            var result = keyCollection[this.keyIndex];
            keyIndex++;
            return result;
        }
    
        public void Write(string data)
        {
            Output += data;
        }
    }
