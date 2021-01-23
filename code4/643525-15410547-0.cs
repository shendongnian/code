    [TestClass]
    public class MyEndpointUnitTests()
    {
       [TestMethod]
       public void SubmitRequestType1()
       {
           //DoStuff for request type 1
       }
       [TestMethod]
       public void SubmitRequestType2()
       {
           //DoStuff for request type 2
       }
       [ClassCleanup]
       public static void Cleanup()
       {
           EndpointLoadTestCleanup.DoCleanup( dbContext = new DbContext( ) );
       }
    }
