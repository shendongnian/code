    class Program
    {
        class Freq
        {
            public int Num { get; set; }
            public int Count { get; set; }
        }
        static void Main(string[] args)
        {
            var nums = new[] { 1, 1, 2, 2, 3, 3, 3, 4 };
            var groups = nums.GroupBy(i => i).Select(g => new Freq { Num = g.Key, Count = g.Count() }).ToList();
            while (groups.Any(g => g.Count > 0))
            {
                var list = groups.Where(g => g.Count > 0).Select(g => g.Num).ToList();
                list.ForEach(li => groups.First(g => g.Num == li).Count--);
                Console.WriteLine(String.Join(",", list));
            }
            Console.ReadKey();
        }
    }
