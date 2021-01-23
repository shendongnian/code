        static void D()
        {
            Action<int> a = null;
            a += x =>
            {
                Console.WriteLine("1> " + x);
            };
            a += x =>
            {
                Console.WriteLine("2> " + x);
                if (x == 42)
                    throw new Exception();
            };
            a += x =>
            {
                Console.WriteLine("3> " + x);
            };
            a(41);
            try
            {
                a(42);  // 2> throwing will prevent 3> from observing 42
            }
            catch { }
            a(43);
        }
        static void S()
        {
            Subject<int> s = new Subject<int>();
            s.Subscribe(x =>
            {
                Console.WriteLine("1> " + x);
            });
            s.Subscribe(x =>
            {
                Console.WriteLine("2> " + x);
                if (x == 42)
                    throw new Exception();
            });
            s.Subscribe(x =>
            {
                Console.WriteLine("3> " + x);
            });
            s.OnNext(41);
            try
            {
                s.OnNext(42);  // 2> throwing will prevent 3> from observing 42
            }
            catch { }
            s.OnNext(43);
        }
