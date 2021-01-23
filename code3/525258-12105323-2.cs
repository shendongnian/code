    // arrange
    var bMock = MockRepository.GenerateMock<IB>();
    var sut = new A(bMock);
    
    // act
    sut.Run("myname");
    
    // assert
    bMock.AssertWasCalled(x => x.SomeCall(Arg<C>.Matches(y => y.Name == "myname"));
