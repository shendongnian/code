    [Test]
    public void ShouldCallMyInternalMethodFromMyMethod()
    {
      myMock = new Mock<MyClass>();
      myMock.Object.MyMethod();
      myMock.Verify(mockObj=> mockObj.MyInternalMethod(), Times.Once());
    }
