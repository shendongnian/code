    using System.Threading;
    
    namespace ConsoleApplication18
    {
        class Program
        {
            static void Main(string[] args)
            {
                TimerCallback[] myTimerCallback = new TimerCallback[3];
    
                myTimerCallback[0] = new TimerCallback(Foo);
                myTimerCallback[0] = new TimerCallback(Bar);
                myTimerCallback[0] = new TimerCallback(FooBar);
            }
        }
    }
