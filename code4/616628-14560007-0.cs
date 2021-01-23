    IHelperClass helperMock = MockRepository.GenerateMock<IHelperClass>();
    helperMock
      .Stub(x => x.HandleFunction<int>())
      .WhenCalled(call => 
      { 
        var delegate = Func<int>)call.Argument[0];
        delegate.Invoke();
      });
    
    // create unit under test, inject mock
    
    unitUnderTest.Foo();
