    public static class ExtensionMethods
    {
        public static bool AnyJR(this IEnumerable t)
        {
            foreach (var o in t)
                return true;
            return false;
        }
        public static bool AnyPhonicUK(this IEnumerable t)
        {
            var e = t.GetEnumerator();
            try {
                return e.MoveNext();
            }
            finally {
                var edisp = e as IDisposable;
                if (edisp != null)
                    edisp.Dispose();
            }
        }
    }
    class Program
    {
        static long Test_AnyJR(List<int> l, int n)
        {
            var sw = Stopwatch.StartNew();
            for (int i = 0; i < n; i++) {
                bool any = l.AnyJR();
            }
            sw.Stop();
            return sw.ElapsedMilliseconds;
        }
        static long Test_AnyPhonicUK(List<int> l, int n)
        {
            var sw = Stopwatch.StartNew();
            for (int i = 0; i < n; i++) {
                bool any = l.AnyPhonicUK();
            }
            sw.Stop();
            return sw.ElapsedMilliseconds;
        }
        static void Main(string[] args)
        {
            var list = new List<int> { 1, 2, 3, 4 };
            
            int N = 10000000;
            Console.WriteLine("{0} iterations using AnyJR took {1} ms.", N, Test_AnyJR(list, N));
            Console.WriteLine("{0} iterations using AnyPhonicUK took {1} ms.", N, Test_AnyPhonicUK(list, N));
            Console.ReadLine();
        }
    }
