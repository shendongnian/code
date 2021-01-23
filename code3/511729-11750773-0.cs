    [TestFixture]
    public class AddRangeTest
    {
        [Test]
        public void AddRange()
        {
            var list = new List<int>();
            var someCollection = new List<int> { 1, 2, 3 };
            var subItems = someCollection.Where(x => x > 1);
            list.AddRange(subItems);
            Assert.AreEqual(2, list.Count);
        }
    }
