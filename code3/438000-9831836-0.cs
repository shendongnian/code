    [Test]
    public void Test1()
    {
        bool wasCalled = false;
        SomeClass someObject = new SomeClass();
        someObject.Finishing += new SomeClass.FinishingEventHandler((sender, a) =>
        {
            wasCalled = true;
        });
        someObject.Start(); // when this method will finish, then call event Finishing
        Thread.Sleep(2000);
        Assert.True(wasCalled);
    }
