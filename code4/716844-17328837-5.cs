    using System;
    using System.Diagnostics;
    
    class Test
    {
        static void Main()
        {
            Random r = new Random(0);
            int[] array = new int[20000000];
            for(int i = 0; i < array.Length; i++)
            {
                array[i] = r.Next(int.MinValue, int.MaxValue);
            }
            Array.Sort(array);
            // JIT everything...
            RunIfElse(array, 1);
            RunConditional(array, 1);
            // Now really time it
            RunIfElse(array, 1000);
            RunConditional(array, 1000);
        }
        
        static void RunIfElse(int[] array, int iterations)
        {        
            long value = 0;
            Stopwatch sw = Stopwatch.StartNew();
            
            for (int x = 0; x < iterations; x++)
            {
                foreach (int i in array)
                {
                    if (i > 0)
                    {
                        value += 2;
                    }
                    else
                    {
                        value += 3;
                    }
                }
            }
            sw.Stop();
            Console.WriteLine("if/else with {0} iterations: {1}ms",
                              iterations,
                              sw.ElapsedMilliseconds);
            // Just to avoid optimizing everything away
            Console.WriteLine("Value (ignore): {0}", value);
        }
    
        static void RunConditional(int[] array, int iterations)
        {        
            long value = 0;
            Stopwatch sw = Stopwatch.StartNew();
            
            for (int x = 0; x < iterations; x++)
            {
                foreach (int i in array)
                {
                    value += i > 0 ? 2 : 3;
                }
            }
            sw.Stop();
            Console.WriteLine("conditional with {0} iterations: {1}ms",
                              iterations,
                              sw.ElapsedMilliseconds);
            // Just to avoid optimizing everything away
            Console.WriteLine("Value (ignore): {0}", value);
        }
    }
