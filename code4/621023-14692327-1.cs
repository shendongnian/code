    public class Example
    {
        private volatile int val = 0;
        public static void Main()
        {
            var example = new Example();
            Task.Run(() => Interlocked.Increment(ref example.val));
            while (example.val == 0) ;
            // this never happens if val is not volatile
            Console.WriteLine("done.");
            Console.ReadLine();
        }
    }
