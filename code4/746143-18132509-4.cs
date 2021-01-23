        public void SillyTuplesTest()
        {
            List<Tuple<string, int, int>> source = new List<Tuple<string, int, int>>()
            {
                Tuple.Create("object0", 1, 2),
                Tuple.Create("object1",1, 2),
                Tuple.Create("object2",1, 3),
                Tuple.Create("object3",2, 1),
                Tuple.Create("object4",2, 3),
                Tuple.Create("object5",3, 2)
            };
            var result = source
                .GroupBy(x => new { min = Math.Min(x.Item2, x.Item3), max = Math.Max(x.Item2, x.Item3) })
                .Select(g => g.First());
            foreach (Tuple<string, int, int> resultItem in result)
            {
                Console.WriteLine("{0} ({1}, {2})", resultItem.Item1, resultItem.Item2, resultItem.Item3);
            }
        }
