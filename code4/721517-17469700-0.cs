    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Threading.Tasks;
    namespace Demo
    {
        class Program
        {
            private void run()
            {
                double sum = 0;
                Func<double, double> func = x => Math.Sqrt(Math.Sin(x));
                object locker = new object();
                double[] data = testData();
                // For each double in data[] we are going to calculate Math.Sqrt(Math.Sin(x)) and
                // add all the results together.
                //
                // To do this, we use class Partitioner to split the input array into just a few partitions,
                // (the Partitioner will use knowledge about the number of processor cores to optimize this)
                // and then add up all the values using a separate thread for each partition.
                //
                // We use threadLocalState to compute the total for each partition, and then we have to
                // add all these together to get the final sum. We must lock the additon because it isn't
                // threadsafe, and several threads could be doing it at the same time.
                Parallel.ForEach
                (
                    Partitioner.Create(0, data.Length),
                    () => 0.0,
                    (subRange, loopState, threadLocalState) =>
                    {
                        for (int i = subRange.Item1; i < subRange.Item2; i++)
                        {
                            threadLocalState += func(data[i]);
                        }
                        return threadLocalState;
                    },
                    finalThreadLocalState =>
                    {
                        lock (locker)
                        {
                            sum += finalThreadLocalState;
                        }
                    }
                );
                Console.WriteLine("Sum = " + sum);
            }
            private static double[] testData()
            {
                double[] array = new double[1000003]; // Test with an odd number of values.
                Random rng = new Random(12345);
                for (int i = 0; i < array.Length; ++i)
                    array[i] = rng.Next() & 3; // Don't want large values for this simple test.
                return array;
            }
            static void Main()
            {
                new Program().run();
            }
        }
    }
