    [Test]
    public void FooPerformance_Pin()
    {
        Assert.That(Time(()=>fooer.Foo()), Is.LessThanOrEqualTo(TimeSpan.FromSeconds(0));
    }
