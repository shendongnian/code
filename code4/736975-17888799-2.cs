    public class TestClass
    {
        private readonly IConsole _console;
    
        public TestClass(IConsole console)
        {
            _console = console;
        }
    
        public void RunBusinessRules()
        {
            int value;
            if(!int.TryParse(_console.ReadLine(), out value)
            {
                throw new ArgumentException("User input was not valid");
            }
        }
    }
    [Test]
    public void TestGettingInput()
    {
        var console = new TestableConsole("abc");
     
        var classObject = new TestClass(console);
    
        Assert.Throws<ArgumentException>(() => classObject.RunBusinessRules());
    }
