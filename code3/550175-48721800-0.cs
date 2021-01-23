    public static void Main(string[] args)
            {
                var list = new List<List<int>> {new List<int> {1, 2, 3, 1, 2, 3, 1, 2, 3, 1, 2, 3, 1, 2, 3, 1, 2, 3, 1, 2, 3, 1, 2, 3, 1, 2, 3, 1, 2, 3, 1, 2, 3,}, new List<int> {1, 2, 31, 2, 3, 1, 2, 3, 1, 2, 3, 1, 2, 3, 1, 2, 3, 1, 2, 3, 1, 2, 3, 1, 2, 3, 1, 2, 3, 1, 2, 3, 6}, new List<int> {1, 2, 3, 1, 2, 3, 1, 2, 3, 1, 2, 3, 1, 2, 3, 1, 2, 3, 9, 10, 11, 1}, new List<int> {1, 2, 3, 1, 2, 3, 1, 2, 3, 1, 2, 3, 1, 2, 3, 1, 2, 3, 1, 2, 3, 1, 2, 3, 1, 2, 3, 1, 2, 3, 1, 2, 3, 9}, new List<int> {1, 2, 31, 2, 3, 1, 2, 3, 1, 2, 3, 1, 2, 3, 1, 2, 3, 1, 2, 3, 1, 2, 3, 1, 2, 3, 1, 2, 3, 1, 2, 3, 6, 7}, new List<int> {1, 2, 3, 1, 2, 3, 1, 2, 3, 1, 2, 3, 1, 2, 3, 1, 2, 3, 9, 10, 11}, new List<int> {1, 2, 3, 1, 2, 3, 1, 2, 3, 1, 2, 3, 1, 2, 3, 1, 2, 3, 1, 2, 3, 1, 2, 3, 1, 2, 3, 1, 2, 3, 1, 2, 3,}, new List<int> {1, 2, 31, 2, 3, 1, 2, 3, 1, 2, 3, 1, 2, 3, 1, 2, 3, 1, 2, 3, 1, 2, 3, 1, 2, 3, 1, 2, 3, 1, 2, 3, 6}, new List<int> {1, 2, 3, 1, 2, 3, 1, 2, 3, 1, 2, 3, 1, 2, 3, 1, 2, 3, 9, 10, 11}};
    
                var sw1 = new Stopwatch();
                sw1.Start();
    
                for (var i = 0; i < 1_000_000; i++)
                {
                    var distinct = list.Select(x => new HashSet<int>(x)).Distinct(HashSet<int>.CreateSetComparer());
                }
    
                sw1.Stop();
                Console.WriteLine($"Method 1: {sw1.Elapsed}");
                
                var sw2 = new Stopwatch();
                sw2.Start();
                for (var i = 0; i < 1_000_000; i++)
                {
                    var distinct = list.GroupBy(a => string.Join(",", a)).Select(a => a.First()).ToList();
    
                }
                sw2.Stop();
                Console.WriteLine($"Method 2: {sw2.Elapsed}");
                
                Console.ReadKey();
            }
