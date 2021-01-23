    public class Etc {
        public static void Foo() {
            DateTime start = ... 
            DateTime stop = ....
            Tuple<DateTime, DateTime>[] intervals = start.GetIntervals(stop).ToArray();
            
            // or simply
            foreach (var interval in start.GetIntervals(stop)) 
                Console.WriteLine(interval);
        }
    }
