    [TestClass]
    public class IEnumerableExtensionsTests
    {
        [TestMethod]
        public void NullList()
        {
            IEnumerable<Test> items = null;
            var flattened = items.Flatten(i => i.Children);
            Assert.AreEqual(0, flattened.Count());
        }
        [TestMethod]
        public void EmptyList()
        {
            var items = new Test[0];
            var flattened = items.Flatten(i => i.Children);
            Assert.AreEqual(0, flattened.Count());
        }
        [TestMethod]
        public void OneItem()
        {
            var items = new[] { new Test() };
            var flattened = items.Flatten(i => i.Children);
            Assert.AreEqual(1, flattened.Count());
        }
        [TestMethod]
        public void OneItemWithChild()
        {
            var items = new[] { new Test { Id = 1, Children = new[] { new Test { Id = 2 } } } };
            var flattened = items.Flatten(i => i.Children);
            Assert.AreEqual(2, flattened.Count());
            Assert.IsTrue(flattened.Any(i => i.Id == 1));
            Assert.IsTrue(flattened.Any(i => i.Id == 2));
        }
        [TestMethod]
        public void OneItemWithNullChild()
        {
            var items = new[] { new Test { Id = 1, Children = new Test[] { null } } };
            var flattened = items.Flatten(i => i.Children);
            Assert.AreEqual(2, flattened.Count());
            Assert.IsTrue(flattened.Any(i => i.Id == 1));
            Assert.IsTrue(flattened.Any(i => i == null));
        }
        class Test
        {
            public int Id { get; set; }
            public IEnumerable<Test> Children { get; set; }
        }
    }
