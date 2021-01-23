    using Microsoft.Win32;
    using System;
    using System.Linq;
    using System.Reactive;
    using System.Reactive.Linq;
    
    namespace ConsoleApp
    {
        class Program
        {
            static void Main(string[] args)
            {
                IDisposable subscriptionToken = 
                    Observable.FromEventPattern(e => SystemEvents.TimeChanged += e, e => SystemEvents.TimeChanged -= e)
                    .Select(x => new Unit())
                    .Throttle(TimeSpan.FromMilliseconds(250))
                    .Subscribe(x => Console.WriteLine("The system clock just changed"));
    
                Console.WriteLine("Press any key to exit");
                Console.ReadKey();
    
                subscriptionToken.Dispose();
            }
        }
    }
