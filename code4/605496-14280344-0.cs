    class MyStateNameService
    {
      private readonly IStateName _remoteService;
      public MyStateNameService(IStateName remoteService)
      {
        // We use ctor injection to denote the mandatory dependency on a IStateName service
        _remoteService = remoteService;
      }
      public string GetStateName(int stateNumber)
      {
        if(stateNumber < 0) throw new ArgumentException("stateNumber");
        // Do not use singletons, prefer injection of dependencies (may be IoC Container)
        //IStateName proxy = XmlRpcProxyGen.Create<IStateName>();
        return _remoteService.GetStateName(stateNumber);
      }
    }
    [TestFixture] class MyStateNameServiceTests
    {
      [Test]
      public void SomeTesting()
      {
        // Arrange
        var mockService = Substitute.For<IStateName>();
        mockService.GetStateName(0).Returns("state1");
        mockService.GetStateName(1).Returns("state2");
        var testSubject = new MyStateNameService(mockService);
        
        // Act
        var result = testSubject.GetStateName(0);
        
        // Assert
        Assert.AreEqual("state1", result);
   
        // Act
        result = testSubject.GetStateName(1);
        
        // Assert
        Assert.AreEqual("state2", result);
   
        // Act/Assert
        Assert.Throws<ArgumentException>(() => testSubject.GetStateName(-1));
        mockService.DidNotReceive().GetStateName(-1);
        /* 
           MyStateNameService does not do much things to test, so this is rather trivial.
           Also different use cases of the testSubject should be their own tests ;) 
        */
      }
    }
