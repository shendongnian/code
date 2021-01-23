        [TestMethod]
        public void T()
        {
            var mySet = new List<string> { "a", "b", "a" };
            var set = from i in mySet
                      group i by i into g
                      select new { Item = g.Key, Percentage = ((double)g.Count()) / mySet.Count() };
            Assert.AreEqual(2, set.Count());
            Assert.AreEqual("a", set.First().Item);
            Assert.AreEqual(2.0/3, set.First().Percentage);
        }
