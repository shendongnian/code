    class Program
    {
        static void Main(string[] args)
        {
            List<string> strArr = new List<string> { "A", "B", "C", "D", "E", "F", "G", "H" };
            IEnumerable<string> result = Process(strArr);
        }
        private static IEnumerable<string> Process(IEnumerable<string> strArr)
        {
            List<string> response = new List<string>();
            int k = 0;
            for (int i = 1; i <= strArr.Count(); i++)
            {
                k++;
                var r = strArr.Combinations(Math.Min(strArr.Count(),k));
                foreach (IEnumerable<string> item in r)
                {
                    foreach (var item1 in r)
                    {
                        foreach (var item2 in item1)
                        {
                            Console.Write(item2);
                        }
                        Console.WriteLine();
                    }
                    if (item.Contains("A") && item.Contains("H"))
                    {
                        var initialCount=strArr.Count();
                        strArr = strArr.Where(j => j != "A" && j != "H");
                        i -= initialCount - strArr.Count();
                    }
                }
            }
            return response;
        }
    }
    public static class Helper
    {
        public static IEnumerable<IEnumerable<T>> Combinations<T>(this IEnumerable<T> elements, int k)
        {
            return k == 0 ? new[] { new T[0] } :
              elements.SelectMany((e, i) =>
                elements.Skip(i + 1).Combinations(k - 1).Select(c => (new[] { e }).Concat(c))
                );
        }
    }
