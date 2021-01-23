    class Program
    {
        static void Main(string[] args)
        {
            MyClass myClass = new MyClass(new ConsoleOutputService(), "Hello World");
            myClass.WriteToConsole();
        }
    }
    
    public interface IOutputService
    {
    
        void WriteLine(string MyProperty);
    }
    
    public class ConsoleOutputService : IOutputService
    {
        public void WriteLine(string MyProperty)
        {
            Console.WriteLine(MyProperty);
        }
    }
    
    class MyClass
    {
        private IOutputService _outputService;
        private string MyProperty { get; set; }
    
        public MyClass(IOutputService outputService, string textToEncapsulate)
        {
            _outputService = outputService;
            MyProperty = textToEncapsulate;
        }
    
        public void WriteToConsole()
        {
            _outputService.WriteLine(MyProperty);
            
        }
    }
