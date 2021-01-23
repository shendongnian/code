    var fixture = new Fixture().Customize(new AutoConfiguredMoqCustomization());
    var mock = fixture.Create<Mock<MyObject>>();
    Assert.NotNull(mock.Object.A);
    Assert.NotNull(mock.Object.B);
    Assert.NotNull(mock.Object.C);
