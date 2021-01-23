    public interface IFoo {
        int Id { get; }
    }
    public class Foo : IFoo {
        public int Id {
            get { return 1; }
        }
    }
    public interface IFooBar : IFoo  {
        string Name { get; }
    }
    public class FooBar : Foo, IFooBar {
        public string Name {
            get { return "AName"; }
        }
    }
    public class ClientOne {
        private readonly IFoo foo;
        public ClientOne(IFoo foo) {
            this.foo = foo;
        }
        public string Details {
            get { return string.Format("Foo : {0}", foo.Id); }
        }
    }
    public class ClientTwo {
        private readonly IFooBar fooBar;
        public ClientTwo(IFooBar fooBar) {
            this.fooBar = fooBar;
        }
        public string Details {
            get { return string.Format("Foo : {0}, Bar : {1}", fooBar.Id, fooBar.Name); }
        }
    }
    [TestMethod]
    public void TestUsingBothClients() {
        var fooBarMock = new Mock<IFooBar>();
        var fooMock = fooBarMock.As<IFoo>();
        fooBarMock.SetupGet(mk => mk.Id).Returns(1);
        fooBarMock.SetupGet(mk => mk.Name).Returns("AName");
        var clientOne = new ClientOne(fooMock.Object);
        var clientTwo = new ClientTwo(fooBarMock.Object);
        Assert.AreEqual("Foo : 1", clientOne.Details);
        Assert.AreEqual("Foo : 1, Bar : AName", clientTwo.Details);
    }
