    [Fact]
    public void Test()
    {
        var fixture = new Fixture()
            .Customize(new WebModelCustomization());
        var sut = fixture.CreateAnonymous<MyController>();
        Assert.IsAssignableFrom<IController>(sut);
    }
