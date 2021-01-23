        [Test]
        public void TestSplit()
        {
            var list = new[] {0, 1, 2, 3, 4, 5, 6, 7, 8, 9};
            IEnumerable<IEnumerable<int>> splitted = list.Split(10);
            Assert.That(splitted.Count(), Is.EqualTo(1));
            Assert.That(splitted.First().Count(), Is.EqualTo(10));
            splitted = list.Split(11);
            Assert.That(splitted.Count(), Is.EqualTo(1));
            Assert.That(splitted.First().Count(), Is.EqualTo(10));
            splitted = list.Split(9);
            Assert.That(splitted.Count(), Is.EqualTo(2));
            Assert.That(splitted.First().Count(), Is.EqualTo(9));
            Assert.That(splitted.ElementAt(1).Count(), Is.EqualTo(1));
            splitted = list.Split(3);
            Assert.That(splitted.Count(), Is.EqualTo(4));
            Assert.That(splitted.First().Count(), Is.EqualTo(3));
            Assert.That(splitted.ElementAt(1).Count(), Is.EqualTo(3));
            Assert.That(splitted.ElementAt(2).Count(), Is.EqualTo(3));
            Assert.That(splitted.ElementAt(3).Count(), Is.EqualTo(1));
        }
