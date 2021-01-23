    private FooController _controller; // object under test, real object
    private Mock<IServiceAdapter> _serviceAdapter; // dependency of controller
    [TestInitialize]
    public void Initialize()
    {
        _serviceAdapter = new Mock<IServiceAdapter>();
        _controller = new FooController(_serviceAdapter.Object);
    }
    [TestMethod()]
    public void SaveTest()
    {
        // Arrange
        string name = "Name1"; 
        string type = "1";
        string parentID = null;
        _serviceAdapter.Setup(x => x.Save(name , type, parentID))
                       .Returns("Success").Verifiable();
        // Act on your object under test!
        // controller will call dependency
        var result =  _controller.Bar(name , type, parentID); 
        // Assert
        Assert.True(result); // verify result is correct
        _serviceAdapter.Verify(); // verify dependency was called
    }
