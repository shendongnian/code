    class Program
    {
        static void Main(string[] args)
        {
            var num = new[] { 3, 1, 8, 5, 2 };
            Func<int, Func<int, IEnumerable<int>>> writeString = 
                delegate(int maxcount)
                {
                    Func<int, IEnumerable<int>> recursiveWrite = null;
                    recursiveWrite = (n) =>
                        {
                            if (n < maxcount)
                            {
                                Console.WriteLine("string " + n);
                                var rec = recursiveWrite(n + 1);
                                return new List<int>(){n}.Concat(rec);
                            }
                            return new List<int>();
                        };
                    return recursiveWrite;
                };
            var newnum = num.SelectMany(n => writeString(6)(n));   // is this possible?
            newnum.ToList().ForEach(w => Console.WriteLine(w));
            Console.ReadLine();
        }
    }
