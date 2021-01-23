    void Test()
    {
            // ARRANGE
            var p = new Mock<IContext>();
            var mockOfPerf = Mock.Of<IPerformanceCounters>();
            p.Setup(e => e.BeginCounter).Returns(mockOfPerf);  // This does not work
            // ACT
            var test = new Test1(p.Object);
            test.React();
                        // ASSERT
            Mock.Get(mockOfPerf).Verify(v=>v.Increment(), Times.Once());
    }
