    struct Item {
        public int Id;
        public int Count;
    }
    class Program {
        static void Main(string[] args) {
            var items = new [] {
                new Item { Id = 1, Count = 12 },
                new Item { Id = 2, Count = 1 },
                new Item { Id = 1, Count = 2 }
            };
            var results =
                from item in items
                group item by item.Id
                into g
                select new { Id = g.Key, Count = g.Sum(item => item.Count) };
            foreach (var result in results) {
                Console.Write(result.Id);
                Console.Write("\t");
                Console.WriteLine(result.Count);
            }
        }
    }
