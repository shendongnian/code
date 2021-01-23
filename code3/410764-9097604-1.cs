    [Test]
    public void ShouldSetResultAfterCallingGetRandomValue()
    { 
        var myClass = new StubMyClass();
        myClass.GetRandomValue();
        int expected = 1234;
        Assert.That(myClass.Result, Is.EqualTo(expected));
    }
