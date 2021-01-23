        [TestMethod]
        [DeploymentItem("Resources\\DSC06247.JPG", "D1")]
        public void TestImageUploadWithRemoval()
        {
            // Arrange
            myDeployedImagePath = Path.Combine(TestContext.DeploymentDirectory, "D1", "DSC06247.JPG");
            // Act ...
        }
    
        [TestMethod]
        [DeploymentItem("Resources\\DSC06247.JPG", "D2")]
        public void TestImageUploadWithoutRemoval()
        {
            // Arrange
            myDeployedImagePath = Path.Combine(TestContext.DeploymentDirectory, "D2", "DSC06247.JPG");
            // Act...
        }
