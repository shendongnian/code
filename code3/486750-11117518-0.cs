    [TestClass]
    public class MyUnitTest
    {
        [TestMethod()]
        [DeploymentItem("myfile.txt")]
        public void MyTestMethod()
        {          
            string file = "myfile.txt";           
            Assert.IsTrue(File.Exists(file), "deployment failed: " + file +
                " did not get deployed");
        }
    }
