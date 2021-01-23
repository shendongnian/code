    var mock = new Mock<IChannelFactory<IService>>();
    mock.Setup(x => x.UseService(It.IsAny<Func<IService, int>>())).Returns(10);
    
    int result = mock.Object.UseService(x => 0);
    
    Console.WriteLine(result);  // prints 10
