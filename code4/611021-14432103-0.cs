    [Test]
    public void IsOverdraftDelegatesToBalanceProvider()
    {
        var result = RandomBool();
        providerMock.Setup(p=>p.IsOverdraft()).Returns(result);
        Assert.That(myObject.IsOverDraft(), Is.EqualTo(result);
    }
