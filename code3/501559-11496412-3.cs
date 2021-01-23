    [Test]
    public void ShouldNotStopDisplayingWarningsWhenTimeRemains()
    {
        Mock<IDisplay> display = new Mock<IDisplay>(MockBehavior.Strict);
        Mock<IScheduler> scheduler = new Mock<IScheduler>(MockBehavior.Strict);
        scheduler.Setup(s => s.Start());
    
        Foo foo = new Foo("Bar", scheduler.Object, display.Object);
        scheduler.Raise(s => s.Alarm += null, new SchedulerEventArgs(1));
    }
