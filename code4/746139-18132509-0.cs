        [Test]
        public void SillyTuplesTest()
        {
            List<Tuple<int, int>> source = new List<Tuple<int, int>>()
            {
                Tuple.Create(1, 2),
                Tuple.Create(1, 2),
                Tuple.Create(1, 3),
                Tuple.Create(2, 1),
                Tuple.Create(2, 3),
                Tuple.Create(3, 2)
            };
            var result = source
                .GroupBy(x => new { min = Math.Min(x.Item1, x.Item2), max = Math.Max(x.Item1, x.Item2) })
                .Select(g => g.First());
            foreach (Tuple<int, int> resultItem in result)
            {
                Console.WriteLine("{0}, {1}", resultItem.Item1, resultItem.Item2);
            }
        }
    Results
    1, 2
    1, 3
    2, 3
