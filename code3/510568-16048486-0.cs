    public class TestDataProvider : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            return new List<int>{ 2, 4, 6 }.GetEnumerator();
        }
    }
    
    [TestFixture]
    public class MyTests
    {
        [TestCaseSource(typeof(TestDataProvider))]
        public void TestOne(int number)
        {
            Assert.That(number % 2, Is.EqualTo(0));
        }
    }
