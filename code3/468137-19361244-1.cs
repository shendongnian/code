    void EnsureSomeObjectPassedToService()
    {
       // arrange
       SomeObject so = new SomeObject()
       // act
       _mainClass.MethodIAmTesting(so);
       // assert
       _someObject.AssertWasCalled(x => x.AnotherMethodCall(so));
    }
