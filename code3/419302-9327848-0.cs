    _viewMock.Expect(x => x.SomeEvent+= Arg<EventHandler<MyEventArgs>>.Is.Anything); 
    Presenter p = new Presenter(_viewMock);
    _mockRepository.ReplayAll();
    ...
    _mockRepository.VerifyAll();
