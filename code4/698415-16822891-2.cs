    using System;
    using System.Reactive.Concurrency;
    using System.Reactive.Linq;
    namespace BallFlight
    {
        class Program
        {
            static void Main()
            {
                var scheduler = new HistoricalScheduler();
                // use this line instead if you need real time
                // var scheduler = Scheduler.Default;
                var interval = TimeSpan.FromSeconds(0.75);
                var subscription =
                    Observable.Interval(interval, scheduler)
                              .TimeInterval(scheduler)
                              .Scan(TimeSpan.Zero, (acc, cur) => acc + cur.Interval)
                              .Subscribe(DrawBall);
                // comment out the next line of code if you are using real time
                // - you can't manipulate real time!
                scheduler.AdvanceBy(TimeSpan.FromSeconds(5));
               
                Console.WriteLine("Press any key...");
                Console.ReadKey(true);
                subscription.Dispose();
            }
            private static void DrawBall(TimeSpan t)
            {
                Console.WriteLine("Drawing ball at T=" + t.TotalSeconds);
            }
        }
    }
