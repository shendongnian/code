    [Test]
    public void GenerateSecretIsAliasForGenerateKey()
    {
        var mockProvider = new Mock<IAuthProvider>();
        var key = GenerateARandomStringSomehow();
        mockProvider.Setup(p=>p.GenerateKey()).Returns(key);
        Assert.That(mockProvider.Object.GenerateSecret(), Is.EqualTo(key));
    }
