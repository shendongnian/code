    public class SomeClass
    {
        public Func<string> Method { get; set; }
        public void PrintSomething()
        {
            if(Method != null) Console.WriteLine(Method());
        }
    }
    // Elsewhere in your application
    var instance = new SomeClass();
    instance.Method = () => "Hello World!";
    instance.PrintSomething(); // Prints "Hello World!"
