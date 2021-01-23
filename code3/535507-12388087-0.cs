    [Test]
    public void test()
    {
        int numEventsRaised = 0;
        subject.SomeEvent += (s, e) => { numEventsRaised++; };
        // Do something which should have triggered the event
        Assert.False((numEventsRaised == 0), "Event was not raised.");
        Assert.False((numEventsRaised > 1), "Event was raised more than once.");
    }
