        public delegate Boolean RefFunc<T>(ref T arg1, Object arg2);
        static void Main(string[] args)
        {
            double loops = 1e6;
            Random random = new Random();
            System.Reflection.MethodInfo m;
            Stopwatch stopwatch = new Stopwatch();
            Type type = typeof(double);
            double tmp;
            stopwatch.Reset();
            stopwatch.Start();
            var deligates = new Dictionary<Type, RefFunc<double>>();
            RefFunc<double> d;
            for (int ii = 0; ii < loops; ii++)
            {
                if (!deligates.TryGetValue(type, out d))
                {
                    m = type.GetMethod("Equals", BindingFlags.Public | BindingFlags.Instance, null, new Type[] { typeof(Object) }, null);
                    d = (RefFunc<double>)Delegate.CreateDelegate(typeof(RefFunc<double>), null, m);
                    deligates[typeof(double)] = d;
                }
                tmp = Convert.ToDouble(random.Next(0, 100));
                d(ref tmp, Convert.ToDouble(random.Next(0, 100)));
            }
            stopwatch.Stop();
            Console.WriteLine("Delegate " + stopwatch.Elapsed.ToString());
            Console.WriteLine("Delegate " + (stopwatch.Elapsed.Ticks / loops).ToString());
            Console.WriteLine("");
        }
