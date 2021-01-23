    var componentMock = MockRepository.GenerateMock<IController>();
    var selectorMock = MockRepository.GenerateMock<ISelector>();
    
    // if you need - specify concrete arguments to return true
    selectorMock.Expect(x => x.Select(null)).IgnoreArguments().Return(true).Repeat.Any();
    componentMock.Expect(x => x.GetSelector()).Return(selectorMock).Repeat.Any();
