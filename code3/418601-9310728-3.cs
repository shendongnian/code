    [TestFixture]
    public class RandomGeneratorTests
    {
        [Test]
        public void GetRandomNumber()
        {
            var collection = new BlockingCollection<double>();
            Parallel.ForEach(Enumerable.Range(0, 1000), i =>
            {
                var random = RandomGenerator.GetRandomNumber();
                collection.Add(random);
            });
            CollectionAssert.AllItemsAreUnique(collection);
        }
    }
