    [TestClass()]
    public sealed class MyClassTest
    {
        [ClassCleanup()]
        public static void ClassCleanup()
        {
            // This method is called after all of the test methods in this
            // test class have finished running...call a cleanup stored procedure
        } 
        
        [TestMethod()]
        public void MyMethodTest()
        {
            // This is where you perform your test
        }
    }
