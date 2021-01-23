    [TestMethod]
    public void EatBanana_CallsWillEat()
    {
        var fakeMonkey = A.Fake<MyMonkey>();
        fakeMonkey.EatBanana(new Banana());
        A.CallTo(()=>fakeMonkey.WillEat(A<Banana>._)).MustHaveHappened();
    }
