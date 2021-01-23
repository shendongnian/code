        static bool done;
        static readonly object _mylock = new object();
        static void Main()
        {
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());
            new Thread(test).Start();
            test();
            Console.ReadKey();
        }
        static void test()
        {
            lock (_mylock)
            {
                if (!done)
                {
                    Console.WriteLine(done);
                    done = true;
                }
            }
        }
