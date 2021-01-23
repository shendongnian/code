    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    namespace Demo
    {
        class Result
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
                // Make 1000 numbers ranging from 0.0 to 100.0 in steps of 0.1
                var numbers = Enumerable.Range(0, 1001).Select(n => n/10.0);
                // Prove that the calculation is correct.
                Console.WriteLine("Result via Linq: " + ViaLinq(numbers));
                Console.WriteLine("Result via loop: " + ViaLoop(numbers));
                // Now do some timings on a much larger list of numbers.
                numbers = Enumerable.Range(0, 1000000).Select(n => n/10.0);
                int count = 100;
                TimeViaLinq(numbers, count);
                TimeViaLoop(numbers, count);
            }
            void TimeViaLinq(IEnumerable<double> numbers, int count)
            {
                var sw = Stopwatch.StartNew();
                for (int i = 0; i < count; ++i)
                    ViaLinq(numbers);
                Console.WriteLine("Via Linq took: " + sw.Elapsed);
            }
            void TimeViaLoop(IEnumerable<double> numbers, int count)
            {
                var sw = Stopwatch.StartNew();
                for (int i = 0; i < count; ++i)
                    ViaLoop(numbers);
                Console.WriteLine("Via Loop took: " + sw.Elapsed);
            }
            Result ViaLinq(IEnumerable<double> numbers)
            {
                return numbers.AsParallel().Aggregate(new Result(), (input, value) => new Result
                {
                    SumAll  = input.SumAll+value,
                    SumAllQ = input.SumAllQ+value*value
                });
            }
            Result ViaLoop(IEnumerable<double> numbers)
            {
                var result = new Result();
                foreach (double number in numbers)
                {
                    result.SumAll  += number;
                    result.SumAllQ += number*number;
                }
                return result;
            }
            static void Main()
            {
                new Program().run();
            }
        }
    }
                                                                              
