    [Test]
    public void TestUpdateSimInfoWithPinAttemptsChangedCallsOnPinAttemptsRemaining()
    {
        int eventFiredCount = 0;
        var info = new SimPinInfo {PinAttemptsRemaining = 10};
        var sim = Sim(info);
        sim.OnPinAttemptsRemaining += (sender, e) => { eventFiredCount++; };
        info.PinAttemptsRemaining = 2;
        sim.UpdateSimInfo(info);
        Assert.AreEqual(1, eventFiredCount);
    }
