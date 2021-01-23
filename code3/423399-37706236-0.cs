        [TestMethod]
        [DeploymentItem("**TestData**")]
        public void TestMethod1()
        {
            Assert.IsTrue(Directory.Exists(@"TestCollisioni\"));
        }
