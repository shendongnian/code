    [Test]
    public void ShouldStopDisplayingWarningsWhenTimeIsOut()
    {
        Mock<IDisplay> display = new Mock<IDisplay>();
        Mock<IScheduler> scheduler = new Mock<IScheduler>();                      
                
        Foo foo = new Foo("Bar", scheduler.Object, display.Object);
        scheduler.Raise(s => s.Alarm += null, new SchedulerEventArgs(0));
    
        display.Verify(d => d.Execute("Bar", WarningState.Ending, null));
        scheduler.Verify(s => s.Stop());
    }
