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
                var interval = TimeSpan.FromSeconds(0.75);
                var subscription =
                    Observable.Interval(interval, scheduler)
                              .TimeInterval(scheduler)
                              .Scan(TimeSpan.Zero, (acc, cur) => acc + cur.Interval)
                              .Subscribe(DrawBall);
                scheduler.AdvanceBy(TimeSpan.FromSeconds(5));
                subscription.Dispose();
                Console.WriteLine("Press any key...");
                Console.ReadKey(true);
            }
            private static void DrawBall(TimeSpan t)
            {
                Console.WriteLine("Drawing ball at T=" + t.TotalSeconds);
            }
        }
    }
