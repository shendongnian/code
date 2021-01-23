    class Program {
        static void Main(string[] args) {
            Walk(3).Where(l => l.Sum() == 20 && 
                l.Skip(1).Where((num, i) => num < l[i]).Count() == 0)
            .ToList().ForEach(l => Console.WriteLine(string.Join(" ", l)));
            Console.ReadLine();
        }
    
        static IEnumerable<List<int>> Walk(int depth) {
            if (depth == 0) {
                yield return new List<int>();
            } else {
                for (int i = 1; i <= 20; i++) {
                    foreach (var l in Walk(depth - 1)) {
                        l.Add(i);
                        yield return l;
                    }
                }
            }
        }
    }
