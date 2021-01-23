    using System;
    using System.Reactive.Concurrency;
    using System.Reactive.Linq;
    
    namespace rxtest
    {
        class FrequencyMeter
        {
            Random rand = new Random();
            public int Hz
            {
                get
                {
                    return rand.Next(100);
                }
            }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                var obs = Observable.Generate<FrequencyMeter, int>(
                    new FrequencyMeter(), //state
                    x => !Console.KeyAvailable, // while no key is pressed
                    x => x, // no change in the state
                    x => x.Hz, // how to get the value
                    x => TimeSpan.FromMilliseconds(250), //how often
                    Scheduler.Default)
                    .DistinctUntilChanged() //show only when changed
                    ;
    
                using (IDisposable handle = obs.Subscribe(x => Console.WriteLine(x)))
                {
                    Console.WriteLine("Interrupt with a keypress");
                    Console.ReadKey();
                }
            }
        }
    }
