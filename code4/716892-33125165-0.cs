    using System;
    using System.Diagnostics;
    namespace ConsoleApplicationTestIfElseVsTernaryOperator
    {
        class Program
        {
            static void Main(string[] args)
            {
                Random r = new Random(0);
                int[] array = new int[20000000];
                for (int i = 0; i < array.Length; i++)
                {
                    array[i] = r.Next(int.MinValue, int.MaxValue);
                }
                Array.Sort(array);
                long value;
                Stopwatch stopwatch = new Stopwatch();
                value = 0;
                stopwatch.Restart();
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
                    // 98 ms
                }
                stopwatch.Stop();
                Console.WriteLine("If/Else: " + stopwatch.ElapsedMilliseconds.ToString() + " ms");
                value = 0;
                stopwatch.Restart();
                foreach (int i in array)
                {
                    value += (i > 0) ? 2 : 3; 
                    // 141 ms
                }
                stopwatch.Stop();
                Console.WriteLine("Ternary: " + stopwatch.ElapsedMilliseconds.ToString() + " ms");
                value = 0;
                int tempVar = 0;
                stopwatch.Restart();
                foreach (int i in array)
                {
                    tempVar = (i > 0) ? 2 : 3;
                    value += tempVar; 
                    // 100ms
                }
                stopwatch.Stop();
                Console.WriteLine("Ternary with temp var: " + stopwatch.ElapsedMilliseconds.ToString() + " ms");
                Console.ReadKey(true);
            }
        }
    }
