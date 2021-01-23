    [TestClass]
    public class UnitTest1
    {
        [DataTestMethod]
        [DataRow(1, 2, 2)]
        [DataRow(2, 3, 5)]
        [DataRow(3, 5, 8)]
        public void AdditionTest(int a, int b, int result)
        {
            Assert.AreEqual(result, a + b);
        }
    }
