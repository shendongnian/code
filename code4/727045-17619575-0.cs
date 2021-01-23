    class Program
    {
        public class Abc
        {
            byte[] _bytes;
            bool _notify;
            public Abc(bool notify = false, int size = 10000000)
            {
                _notify = notify;
                _bytes = new byte[size];
                if (notify) Console.WriteLine("Constructor called");
            }
            ~Abc()
            {
                if (_notify) Console.WriteLine("***** Destructor called *****");
                else Console.Write("!");
                System.Diagnostics.Debug.WriteLine("Destructor called");
            }
        }
        static void Main(string[] args)
        {
            // type 1, hold reference
            Abc abc = new Abc(true, 100000000);
            // type 2, throw away
            new Abc(true, 100000000);
            int i = 0;
            while (true)
            {
                Thread.Sleep(100);
                Console.Write(i++ + "...");
                // keep allocating memory so that GC will be forced ...
                new Abc();
            }
        }
    }
