    public class Scenario
    {
        [Fact]
        public void CreateMyObject()
        {
            var fixture = new Fixture().Customize(new MockHybridCustomization());
            var actual = fixture.CreateAnonymous<MyObject>();
            Assert.NotNull(actual.A);
            Assert.NotNull(actual.B);
            Assert.NotNull(actual.C);
        }
        [Fact]
        public void MyObjectIsMock()
        {
            var fixture = new Fixture().Customize(new MockHybridCustomization());
            var actual = fixture.CreateAnonymous<MyObject>();
            Assert.NotNull(Mock.Get(actual));
        }
        [Fact]
        public void CreateMyParent()
        {
            var fixture = new Fixture().Customize(new MockHybridCustomization());
            var actual = fixture.CreateAnonymous<MyParent>();
            Assert.NotNull(actual.Object);
            Assert.NotNull(actual.Text);
            Assert.NotNull(Mock.Get(actual.Object));
        }
        [Fact]
        public void MyParentIsMock()
        {
            var fixture = new Fixture().Customize(new MockHybridCustomization());
            var actual = fixture.CreateAnonymous<MyParent>();
            Assert.NotNull(Mock.Get(actual));
        }
    }
