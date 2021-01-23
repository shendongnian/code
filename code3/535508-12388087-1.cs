    [Test]
    public void test()
    {
        int numEventsRaised = 0;
        subject.SomeEvent += (s, e) => { numEventsRaised++; };
        // Do something which should have triggered the event
        //As per the OP's example, we will wait 5 seconds to ensure
        //the async event has time to be raised.
        Thread.Sleep(5000);
        Assert.False((numEventsRaised == 0), "Event was not raised.");
        Assert.False((numEventsRaised > 1), "Event was raised more than once.");
    }
