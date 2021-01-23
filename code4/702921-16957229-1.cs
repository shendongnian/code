    [TestInitialize]
    public void InitializeTestEnvironment()
    {
        _testTarget = new ThreadPoolTimerBuilder().WithAutoResetOption(true)
                                                  .WithInterval(100)
                                                  .Build() as ThreadPoolTimer;
        Assert.IsNotNull(_testTarget);
        _spy = new ThreadPoolTimerSpy(_testTarget);
    }
    [TestMethod]
    public void IntervalElapsedMustBeRaisedExactlyTenTimesAfter1000Milliseconds()
    {
        CheckIntervalElapsed(10, TimeSpan.FromMilliseconds(1000), TimeSpan.FromMilliseconds(100));
    }
    private void CheckIntervalElapsed(int numberOfIntervals, TimeSpan expectedTime, TimeSpan toleranceInterval)
    {
        _spy.NumberOfIntervals = numberOfIntervals;
        _spy.Measure();
        var passedTime = _spy.EndTime - _spy.StartTime;
        var timingDifference = Math.Abs(expectedTime.Milliseconds - passedTime.Milliseconds);
        Assert.IsTrue(timingDifference <= toleranceInterval.Milliseconds, string.Format("Timing difference: {0}", timingDifference));
    }
