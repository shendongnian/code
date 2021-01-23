            var listA = new List<int> {2, 2, 2};
            var listB = new List<int> {2, 2, 3};
            var grouppedA = listA.GroupBy(i => i).Select(g => new { key = g.Key, count = g.Count()});
            var grouppedB = listB.GroupBy(i => i).Select(g => new { key = g.Key, count = g.Count()});
            var result = grouppedA
                .Union(grouppedB)
                .GroupBy(g => g.key)
                .SelectMany(g => Enumerable.Repeat(g.Key, g.Max(h => h.count)));
            foreach (int i in result)
            {
                Console.Write(i + " ");
            }
            Console.ReadKey();
