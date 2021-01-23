        void TestIt()
        {
            var ints = new int[10000000];
            Random rand = new Random();
            for (int i = 0; i < ints.Length; i++)
                ints[i] = rand.Next(100);
            Func<int, int> func1 = i => i + 2;
            Func<int, int> func2 = CompileIt();
            var stopwatch = new Stopwatch();
            for (int x = 0; x < 3; x++)
            {
                stopwatch.Restart();
                for (int i = 0; i < ints.Length; i++)
                    ints[i] = func1(ints[i]);
                stopwatch.Stop();
                Console.Write("Lamba                       ");
                Console.Write(stopwatch.ElapsedMilliseconds);
                ShowSum(ints);
                stopwatch.Restart();
                for (int i = 0; i < ints.Length; i++)
                    ints[i] = func2(ints[i]);
                stopwatch.Stop();
                Console.Write("Lambda from expression tree ");
                Console.Write(stopwatch.ElapsedMilliseconds);
                ShowSum(ints);
                stopwatch.Restart();
                for (int i = 0; i < ints.Length; i++)
                    ints[i] = AddTwo(ints[i]);
                stopwatch.Stop();
                Console.Write("Compiled function           ");
                Console.Write(stopwatch.ElapsedMilliseconds);
                ShowSum(ints);
                stopwatch.Restart();
                for (int i = 0; i < ints.Length; i++)
                    ints[i] = ints[i] + 2;
                stopwatch.Stop();
                Console.Write("Compiled code               ");
                Console.Write(stopwatch.ElapsedMilliseconds);
                ShowSum(ints);
            }
        }
        private int AddTwo(int value)
        {
            return value + 2;
        }
        private void ShowSum(int[] ints)
        {
            Console.WriteLine("    Sum = " + ints.Sum(i => i).ToString());
        }
        private Func<int, int> CompileIt()
        {
            var param1 = Expression.Parameter(typeof(int));
            Expression body = Expression.Add(param1, Expression.Constant(2));
            return Expression.Lambda<Func<int, int>>(body, new [] { param1 }).Compile();
        }
