    [Test]
    public void ShouldRaiseFinishedEvent()
    {
        SomeClass someObject = new SomeClass();
        AutoResetEvent eventRaised = new AutoResetEvent(false);
        someObject.SomethingFinished += (o, e) => { eventRaised.Set(); };
    
        someObject.DoSomething();
        Assert.IsTrue(eventRaised.WaitOne(TimeSpan.FromMilliseconds(500)));
    }
