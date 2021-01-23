    using Microsoft.VisualStudio.TestTools.UnitTesting;
    
    namespace Company.Product.Area
    {
        [TestClass]
        public class MyTestSuite : TestInits
        {
            [ClassInitialize]
            public static void MyClassInit(TestContext tc)
            {
                MyInitTestSuite();
            }
    
            [ClassCleanup]
            public static void MyClassCleanup()
            {
                MyCleanupTestSuite();
            }
    
            [TestMethod]
            public void My_First_Test()
            {
                ...
            }
     
            public static void MyInitTestSuite()
            {
                // Setup driver
                // Navigate to site
                // Login
            }
    
            public static void MyCleanupTestSuite()
            {
                // Quit Driver
            }
        }
    }
