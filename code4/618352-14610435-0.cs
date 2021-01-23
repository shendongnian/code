    MockRepository mock = new MockRepository();
    var mockTest = mock.PartialMock<Test>();
    mockTest.Expect(m => m.MethodOne());
    mock.ReplayAll();
    mock.VerifyAll();
