    string expectedMessage = "RhinoMocks baby!";
    string actualMessage = "RhinoMocks dude!";
    var fooMock = MockRepository.GenerateMock<ifoo>();
    fooMock.Bar(actualMessage);
     
    var calls = fooMock.GetArgumentsForCallsMadeOn(x => x.Bar(string.Empty), o => o.IgnoreArguments());
    Assert.AreEqual(1, calls.Count);
    var arguments = calls[0];
    Assert.AreEqual(expectedMessage, arguments[0]);
