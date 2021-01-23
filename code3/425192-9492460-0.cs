    private void TestCreate()
    {
        var mocker = new Mock<ISomeInterface>();
        mocker.Setup(x => x.Create(It.IsAny<SomeClass>())).Returns(3);
        var result = mocker.Object.Create(new SomeClass());
    }
    private void TestCreate()
    {
        var mocker = new Mock<ISomeInterface>();
        var someClass = new SomeClass();
        mocker.Setup(x => x.Create(someClass)).Returns(3);
        var result = mocker.Object.Create(someClass);
    }
