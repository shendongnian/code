    [Test]
    public void FooPerformance_Pin()
    {
        Assert.That(Time(()=>fooer.Foo()), Is.LessThanOrEqualTo(TimeSpan.FromSeconds(0.8));
    }
    [Test]
    public void BarPerformance_Pin()
    {
        Assert.That(Time(()=>fooer.Bar()), Is.LessThanOrEqualTo(TimeSpan.FromSeconds(6));
    }
