    IHelperClass helperMock = MockRepository.GenerateMock<IHelperClass>();
    helperMock
      .Stub(x => x.HandleFunction<int>())
      .WhenCalled(call => 
      { 
        var handler = (Func<int>)call.Argument[0];
        handler.Invoke();
      });
    
    // create unit under test, inject mock
    
    unitUnderTest.Foo();
