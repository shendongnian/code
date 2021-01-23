    [Test]
    public void Start_WithValidParameters_TriggersTimeReached()
    {
        var subscriberMock = new Mock<ISubscriber>();
        var timer = new TimeOutTimer(subscriberMock.Object);        
        timer.Start();
        Thread.Sleep(1000);
    
        subscriberMock.Verify(subscriber => subscriber.TimeReached());
    }
