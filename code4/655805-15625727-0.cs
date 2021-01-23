    using System;
    using System.Threading;
    using System.Threading.Tasks;
    namespace Demo
    {
        internal class Program
        {
            private static void Main(string[] args)
            {
                int readerCount = 4;
                Barrier barrier1 = new Barrier(readerCount + 1);
                Barrier barrier2 = new Barrier(readerCount + 1);
                for (int i = 0; i < readerCount; ++i)
                {
                    Task.Factory.StartNew(() => reader(barrier1, barrier2));
                }
                while (true)
                {
                    barrier1.SignalAndWait(); // Wait for all threads to reach the "new data available" point.
                
                    if ((value % 10000) == 0)       // Print message every so often.
                        Console.WriteLine(value);
                    barrier2.SignalAndWait(); // Wait for the reader threads to read the current value.
                    ++value;                  // Produce the next value.
                }
            }
            private static void reader(Barrier barrier1, Barrier barrier2)
            {
                int expected = 0;
                while (true)
                {
                    barrier1.SignalAndWait(); // Wait for "new data available".
                    if (value != expected)
                    {
                        Console.WriteLine("Expected " + expected + ", got " + value);
                    }
                    ++expected;
                    barrier2.SignalAndWait();  // Signal that we've read the data, and wait for all other threads.
                }
            }
            private static volatile int value;
        }
    }
