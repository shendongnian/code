    [TestClass]
    public class UtilityTest
    {
        [TestMethod]
        public void TestInternalMethodWithDynamic() {
            int parameter = 10;
            Assert.AreEqual(10, Utility.InternalMethodWithDynamic(parameter));
        }
    }
