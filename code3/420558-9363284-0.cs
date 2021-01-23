    [Test]
    public void DoSomething_WhenCalled_EventFired()
    {
      FileSystem fs = new FileSystem(mock.Object, timerMock.Object);
            
      bool WasItHit = false;
      fs.EventHit += delegate { WasItHit = true; };
      fs.DoSomething(); //This should call the event
      Assert.IsTrue(WasItHit);
    }
