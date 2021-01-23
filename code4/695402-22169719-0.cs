 
    [TestClass]
    public class TestMyClass
    {
        [TestMethod]
        [DeploymentItem("firstnative.dll")]
        [DeploymentItem("secondnative.dll")]
        public void TestMyMethod()
        {
            //Code which (indirectly) uses the above native dlls.
        }
    }
