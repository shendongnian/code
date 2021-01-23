    [Fact]
    public void ContainerCorrectlyResolvesDepender1()
    {
        var container = new UnityContainer().AddNewExtension<MyConventions>();
        var actual = container.Resolve<Depender1>();
        var deco = Assert.IsAssignableFrom<DecoratingThing>(actual.Thing);
        var thing = Assert.IsAssignableFrom<RealThing>(deco.Thing);
        Assert.Equal("Config1", thing.Configuration);
    }
    [Fact]
    public void ContainerCorrectlyResolvesDepender2()
    {
        var container = new UnityContainer().AddNewExtension<MyConventions>();
        var actual = container.Resolve<Depender2>();
        var deco = Assert.IsAssignableFrom<DecoratingThing>(actual.Thing);
        var thing = Assert.IsAssignableFrom<RealThing>(deco.Thing);
        Assert.Equal("Config2", thing.Configuration);
    }
    [Fact]
    public void ContainerCorrectlyResolvesDepender3()
    {
        var container = new UnityContainer().AddNewExtension<MyConventions>();
        var actual = container.Resolve<Depender3>();
        var deco = Assert.IsAssignableFrom<DecoratingThing>(actual.Thing);
        var thing = Assert.IsAssignableFrom<RealThing>(deco.Thing);
        Assert.Equal("Config3", thing.Configuration);
    }
