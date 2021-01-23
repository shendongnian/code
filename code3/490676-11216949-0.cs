    class Program
    {
        public class Context
        {
            public int count;
        }
        static Context AggregateContext(Context c, long i)
        {
            c.count++;
            return c;
        }
        static void OnWindow(Context c) { Console.WriteLine(c.count); }
        static void Main(string[] args)
        {
            var canceled = new Subject<bool>();
            var observable = Observable.Interval(TimeSpan.FromSeconds(.1)).TakeUntil(canceled);
            var windows = observable.Window(TimeSpan.FromSeconds(3));
            var aggregatedWindows = windows.SelectMany(
                window => window.Aggregate(new Context(), AggregateContext));
            var subscription = aggregatedWindows.Subscribe(OnWindow);
            Thread.Sleep(TimeSpan.FromSeconds(10));
            canceled.OnNext(true);
            subscription.Dispose();
            Console.WriteLine( @"Output should have been something like 30,30,30,30,10" );
            Console.ReadLine();
        }
    } 
