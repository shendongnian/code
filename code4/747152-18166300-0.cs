    [Fact]
    public void MethodName()
    {
        var fixture = new Fixture().Customize(new AutoMoqCustomization());
        const string expected = "Foo";
        fixture.Customize<OrderLine>(o => o
            .FromFactory(() =>
                new OrderLine(expected)));
        var order = fixture.Create<Order>();
    }
