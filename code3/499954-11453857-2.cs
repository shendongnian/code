    [TestMethod]
    public void Prop2ShouldReturnTwoValueIfSomeSettingEqualsSetting2()
    {
        var moqConfig = new Mock<ISomeConfiguration>();
        moqConfig.Setup(p => p.SomeSetting).Returns("setting2");
        var sut = new SomeClass(moqConfig.Object);
        Assert.That(sut.Prop2, Is.EqualTo("two"));
    }
