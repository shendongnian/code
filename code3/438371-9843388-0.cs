    class Helper
    {
        private const int X = 50;
        private const int Y = 10;
    
        private static Lazy<List<double>> lazy = new Lazy<List<double>>(() => (from horizontal in Enumerable.Range(0, X)
                                                                               from vertical in Enumerable.Range(0, Y)
                                                                               select Process(horizontal, vertical)).ToList());
        // Didn't know what Process was
        static double Process(double h, double v)
        {
            return h * v;
        }
    
        public static void Method()
        {
            List<double> data = lazy.Value;
            foreach (double value in data)
                Console.WriteLine(value);
        }
    }
