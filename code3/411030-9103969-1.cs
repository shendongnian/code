    class Program {
        static void Main(string[] args) {
            Walk(3).Where(l => l.Sum() == 20 &&
                l.Skip(1).Where((num, i) => num < l[i]).Count() == 0)
            .ToList().ForEach(l => Console.WriteLine(string.Join(" ", l)));
            Console.ReadLine();
        }
    
        static IEnumerable<List<int>> Walk(int depth) {
            return depth == 0 ? 
                new[] { new List<int>()} :
                Enumerable.Range(1,20).SelectMany(i =>
                    Walk(depth - 1).Select(l => l.Concat(new[] {i}).ToList()));
        }
    }
