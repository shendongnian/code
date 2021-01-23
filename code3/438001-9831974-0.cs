    [Test]
    public void ShouldRaiseFinishedEvent()
    {
        SomeClass someObject = new SomeClass();
        bool eventRaised = false;
        someObject.SomethingFinished += (o, e) => { eventRaised = true; };
        someObject.DoSomething();
        Assert.That(eventRaised, Is.True.After(500));
    }
