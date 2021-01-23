    [TestMethod]
    public void ShouldSaveEntityWithStatusInitialized()
    {
        // arrange
        var mock = new Mock<IRepository>();
        mock.Setup(m => m.InsertEntity(It.Is<Entity>(e => e.Status == "Initialized")));
        var processor = new Processor(mock.Object);
        // act
        processor.Execute("test");
   
        // assert
        mock.Verify();
    }
