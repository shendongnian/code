    [TestClass]
    public abstract class IComponentTest
    {
        [TestMethod]
        public void TestMethodA()
        {
             // Interface level expectations.
        }
        [TestMethod]
        public void TestMethodB()
        {
             // Interface level expectations.
        }
    }
    
    [TestClass]
    public class ComponentTest : IComponentTest
    {
        [TestMethod]
        public void TestMethodACustom()
        {
            // Test Component specific test, not general test
        }
        [TestMethod]    
        public void TestMethodBCustom()
        {
            // Test Component specific test, not general test
        }
    }
    [TestClass]
    public class ExtendedComponent : ComponentTest 
    {
        public void TestMethodACustom2()
        {
            // Test Component specific test, not general test
        }
    }
