    static void runIfElse(int[] array, int iterations)
        {
            long value = 0;
            Stopwatch ifElse = new Stopwatch();
            ifElse.Start();
            for (int c = 0; c < iterations; c++)
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
            ifElse.Stop();
            Console.WriteLine(String.Format("Elapsed time for If-Else: {0}", ifElse.Elapsed));
        }
        static void runTernary(int[] array, int iterations)
        {
            long value = 0;
            Stopwatch ternary = new Stopwatch();
            ternary.Start();
            for (int c = 0; c < iterations; c++)
            {
                foreach (int i in array)
                {
                    value += i > 0 ? 2 : 3;
                }
            }
            ternary.Stop();
            Console.WriteLine(String.Format("Elapsed time for Ternary: {0}", ternary.Elapsed));
        }
        static void Main(string[] args)
        {
            Random r = new Random();
            int[] array = new int[20000000];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = r.Next(int.MinValue, int.MaxValue);
            }
            Array.Sort(array);
            long value = 0;
            runIfElse(array, 1);
            runTernary(array, 1);
            runIfElse(array, 1000);
            runTernary(array, 1000);
            
            Console.ReadLine();
        }
