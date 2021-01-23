    [Test]
    public void test()
    {
        var eventRaised = new ManualResetEvent(false);
        var counter = 0;
        subject.SomeEvent += (s, e) => { if (++counter) >= 2 eventRaised.Set(); };
    
        // Do something which should have triggered the event
    
        // you might want to decrease the timeout
        Assert.False(eventRaised.WaitOne(5000), "Event was not raised.");
        Assert.AreEqual(1, counter);
    }
