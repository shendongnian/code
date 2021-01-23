    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            ClassLibrary1.Child myChild = new ClassLibrary1.Child();
            using (ShimsContext.Create())
            {
                ClassLibrary1.Fakes.ShimChild.AllInstances.addressGet = (instance) => "foo";
                ClassLibrary1.Fakes.ShimParent.AllInstances.NameGet = (instance) => "bar";
                Assert.AreEqual("foo", myChild.address);
                Assert.AreEqual("bar", myChild.Name);
            }
        }
    }
