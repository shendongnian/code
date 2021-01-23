    [Test]
    public void TestOnStatusIsNotFired()
    {
        Sim sim = new Sim();
        var mre = new ManualResetEvent(false);
        sim.OnStatus += onStatus => { mre.Set(); Assert.Fail("OnStatus Was called");}
        sim.NoStatus += () => { mre.Set();}
        sim.UpdateSimInfo(new Info("the same status"));
        mre.WaitOne()
    }
