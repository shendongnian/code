    public void TestBusinessLogic()    
    {
        MySingleton fakeSingleton = new Mock<MySingleton>();
        fakeSingleton.Setup(s => s.InitialValue).Returns(5);
      
        // Register the fake in the ServiceLocator
        ServiceLocator.Register<MySingleton>(fakeSingleton.Object);
    
        // Run
        MyBusinessMethod();
  
        // Assert        
        fakeSingleton.Verify (s => s.SaveProcessedValue()).Called(Exactly.Once);
    } 
