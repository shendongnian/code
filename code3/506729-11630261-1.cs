    using System.Threading;
    
    namespace ConsoleApplication18
    {
        class Program
        {
            static void Main(string[] args)
            {
                var callbacks = new TimerCallback[]
                {    
                  new TimerCallback(Foo),
                  new TimerCallback(Bar),
                  new TimerCallback(FooBar)
            }
        }
    }
