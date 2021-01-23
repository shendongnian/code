    public class TestableConsole : IConsole
    {
        private readonly string _output;
    
        public TestableConsole(string output)
        {
            _output = output;
        }
    
        public string ReadLine()
        {
            return _output;
        }
    }
