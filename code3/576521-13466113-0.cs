    void Test()
    {
        // ARRANGE
        var p = new Mock<IContext>();
        var perfCountMock = new Mock<IPerformanceCounters>();
        p.Setup(e => e.BeginCounter).Returns(() => perfCountMock.Object);  // This does not work
        perfCountMock.Setup(e => e.Increment());
    
        // ACT
        var test = new Test(p.Object);
        test.React();
    
        // ASSERT
        perfCountMock.Verify(v => v.Increment(), Times.Once());
    }
