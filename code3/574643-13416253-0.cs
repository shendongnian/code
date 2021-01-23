    [TestClass]
    public class Test1 : SomeClass
    {
        [TestMethod]
        public void MyTest
        {
            Assert.AreEqual(1, ProtectedMethod());
        }
    }
