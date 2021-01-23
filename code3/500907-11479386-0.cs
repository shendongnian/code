    class Program
    {
        private static int _lifeState;
        private static bool _end;
        private sealed class Schrodinger
        {
            private int _x;
            public Schrodinger()
            {
                //Here I'm using 'this'
                _x = 1;
                //But now I no longer reference 'this'
                _lifeState = 1;
                //Keep busy to provide an opportunity for GC to collect me
                for (int i=0;i<10000; i++)
                {
                    var garbage = new char[20000];
                }
                //Did I die before I finished being constructed?
                if (Interlocked.CompareExchange(ref _lifeState, 0, 1) == 2)
                {
                    Console.WriteLine("Am I dead or alive?");
                    _end = true;
                }
            }
            ~Schrodinger()
            {
                _lifeState = 2;
            }
        }
        static void Main(string[] args)
        {
            //Keep the GC churning away at finalization to demonstrate the case
            Task.Factory.StartNew(() =>
                {
                    while (!_end)
                    {
                        GC.Collect();
                        GC.WaitForPendingFinalizers();
                    }
                });
            //Keep constructing cats until we find the desired case
            int catCount = 0;
            while (!_end)
            {
                catCount++;
                var cat = new Schrodinger();
                while (_lifeState != 2)
                {
                    Thread.Yield();
                }
            }
            Console.WriteLine("{0} cats died in the making of this boundary case", catCount);
            Console.ReadKey();
        }
    }
