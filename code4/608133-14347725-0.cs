    [TestFixture]
    public class Class1
    {
        [Test]
        public void TestMethod()
        {
            Mock<Thing> _thing = new Mock<Thing>();
            Expression<Func<Thing, string>> setup = t => t.PropA.SubPropB;
    //                               ^ works with string and object
            _thing.Setup(setup).Returns(string.Empty);
            Assert.IsEmpty(_thing.Object.PropA.SubPropB);
        }
    }
    public class Thing
    {
        public virtual Thingy PropA { get; set; }
    }
    public class Thingy
    {
        public virtual string SubPropB { get; set; }
    }
