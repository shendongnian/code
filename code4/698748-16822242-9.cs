    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading.Tasks;
    namespace Demo
    {
        public class Result
        {
            public double SumAll;
            public double SumAllQ;
        
            public override string ToString()
            {
                return string.Format("SumAll={0}, SumAllQ={1}", SumAll, SumAllQ);
            }
        }
    
        class Program
        {
            void run()
            {
                var numbers = Enumerable.Range(0, 1000000).Select(n => n/10.0).ToArray();
                // Prove that the calculation is correct.
                Console.WriteLine("Result via Linq:      " + ViaLinq(numbers));
                Console.WriteLine("Result via loop:      " + ViaLoop(numbers));
                Console.WriteLine("Result via partition: " + ViaPartition(numbers));
                int count = 100;
                TimeViaLinq(numbers, count);
                TimeViaLoop(numbers, count);
                TimeViaPartition(numbers, count);
            }
            void TimeViaLinq(double[] numbers, int count)
            {
                var sw = Stopwatch.StartNew();
                for (int i = 0; i < count; ++i)
                    ViaLinq(numbers);
                Console.WriteLine("Via Linq took: " + sw.Elapsed);
            }
            void TimeViaLoop(double[] numbers, int count)
            {
                var sw = Stopwatch.StartNew();
                for (int i = 0; i < count; ++i)
                    ViaLoop(numbers);
                Console.WriteLine("Via Loop took: " + sw.Elapsed);
            }
            void TimeViaPartition(double[] numbers, int count)
            {
                var sw = Stopwatch.StartNew();
                for (int i = 0; i < count; ++i)
                    ViaPartition(numbers);
                Console.WriteLine("Via Partition took: " + sw.Elapsed);
            }
            Result ViaLinq(double[] numbers)
            {
                return numbers.AsParallel().Aggregate(new Result(), (input, value) => new Result
                {
                    SumAll  = input.SumAll+value,
                    SumAllQ = input.SumAllQ+value*value
                });
            }
            Result ViaLoop(double[] numbers)
            {
                var result = new Result();
                for (int i = 0; i < numbers.Length; ++i)
                {
                    double n = numbers[i];
                    result.SumAll  += n;
                    result.SumAllQ += n*n;
                }
                return result;
            }
            Result ViaPartition(double[] numbers)
            {
                var result = new Result();
                var rangePartitioner = Partitioner.Create(0, numbers.Length);
                Parallel.ForEach(rangePartitioner, (range, loopState) =>
                {
                    var subtotal = new Result();
                    for (int i = range.Item1; i < range.Item2; i++)
                    {
                        double n = numbers[i];
                        subtotal.SumAll  += n;
                        subtotal.SumAllQ += n*n;
                    }
                    lock (result)
                    {
                        result.SumAll  += subtotal.SumAll;
                        result.SumAllQ += subtotal.SumAllQ;
                    }
                });
                return result;
            }
            static void Main()
            {
                new Program().run();
            }
        }
    }
                                                                              
