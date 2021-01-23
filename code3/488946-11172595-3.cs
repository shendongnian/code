    [TestFixture]
    public class EnumerablesTests
    {
        [Test]
        public void TestTopN()
        {
            var input = new[] { 1, 2, 8, 3, 6 };
            var output = input.TopN(n => n, 3).ToList();
            Assert.AreEqual(3, output.Count);
            Assert.IsTrue(output.Contains(8));
            Assert.IsTrue(output.Contains(6));
            Assert.IsTrue(output.Contains(3));
        }
        [Test]
        public void TestBottomN()
        {
            var input = new[] { 1, 2, 8, 3, 6 };
            var output = input.BottomN(n => n, 3).ToList();
            Assert.AreEqual(3, output.Count);
            Assert.IsTrue(output.Contains(1));
            Assert.IsTrue(output.Contains(2));
            Assert.IsTrue(output.Contains(3));
        }
        [Test]
        public void TestTopNDupes()
        {
            var input = new[] { 1, 2, 8, 8, 3, 6 };
            var output = input.TopN(n => n, 3).ToList();
            Assert.AreEqual(3, output.Count);
            Assert.IsTrue(output.Contains(8));
            Assert.IsTrue(output.Contains(6));
            Assert.IsFalse(output.Contains(3));
        }
        [Test]
        public void TestBottomNDupes()
        {
            var input = new[] { 1, 1, 2, 8, 3, 6 };
            var output = input.BottomN(n => n, 3).ToList();
            Assert.AreEqual(3, output.Count);
            Assert.IsTrue(output.Contains(1));
            Assert.IsTrue(output.Contains(2));
            Assert.IsFalse(output.Contains(3));
        }
    }
