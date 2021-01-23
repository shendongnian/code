    var mock = MockRepository.GenerateMock<IA>();
    mock
      .Stub(x => x.DoSomething(Arg<IC>.Is.Anything)
      // return a new instance of B each time
      .WhenCalled(call => call.ReturnValue = new B((IC)call.Arguments[0]))
      // make rhino mock validation happy
      .Return(null);
