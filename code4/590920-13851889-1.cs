    [TestClass]
    public class TestClass1
    {
        private static void ExecuteTestCore<T>() where T : new(), IHaveAMethod
        {
            var x = new T().SomeMethod();
            Assert.IsNotNull(x);
        }
        [TestMethod]
        public void TestMethod1()
        {
            TestClass1.ExecuteTestCore<ChildClass1>();
        }
        [TestMethod]
        public void TestMethod2()
        {
            TestClass1.ExecuteTestCore<ChildClass2>();
        }
        // 10+ more of the same.
    }
    internal interface IHaveAMethod
    {
        void SomeMethod();
    }
