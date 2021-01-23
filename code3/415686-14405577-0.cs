    //setup test input
    int testInput = 1;
    int someOutput = 10;
    //Setup the service to expect a specific call with specific input
    //output is irrelevant, because we won't be comparing it to anything
    Mock<IService> mockService = new Mock<IService>(MockBehavior.Strict);
    mockService.Setup(x => x.Calculate(testInput)).Returns(someOutput).Verifiable();
    //Setup the factory to pass requests through to our mocked IService
    //This uses a lambda expression in the return statement to call whatever delegate you provide on the IService mock
    Mock<IChannelFactory<IService>> mockFactory = new Mock<IChannelFactory<IService>>(MockBehavior.Strict);
    mockFactory.Setup(x => x.UseService(It.IsAny<Func<IService, int>>())).Returns((Func<IService, int> serviceCall) => serviceCall(mockService.Object)).Verifiable();
    //Instantiate the object you're testing, and pass in the IChannelFactory
    //then call whatever method that's being covered by the test
    //
    //var target = new object(mockFactory.Object);
    //target.targetMethod(testInput);
    //verifying the mocks is all that's needed for this unit test
    //unless the value returned by the IService method is used for something
    mockFactory.Verify();
    mockService.Verify();
