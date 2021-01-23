    var controllerMock = new Mock<IController>();
    controllerMock.Setup(m => m.DoSomeStuff()).Returns(11);
    // assuming appropriate ctors
    var testableEntity = new TestableEntity(controllerMock);
    testableEntity.PublishReturnValue = 999;
    var result = testableEntity.Process();
    Assert.AreEqual(999, result);        
