    public interface IFoo {
        string Bar();
    }
    public class Snafu {
        private IFoo _foo;
        public Snafu(IFoo foo) {
            _foo = foo;
        }
        public string GetGreeting() {
            return string.Format("{0} {1}",
                                 _foo.Bar(),
                                 _foo.Bar());
        }
    }
    [TestMethod]
    public void UsingSequences() {
        var mockFoo = new Mock<IFoo>();
        mockFoo.SetupSequence(mk => mk.Bar()).Returns("Hello").Returns("World");
        var snafu = new Snafu(mockFoo.Object);
        Assert.AreEqual("Hello World", snafu.GetGreeting());
    }
    [TestMethod]
    public void NotUsingSequences() {
        var pieces = new[] {
                "Hello",
                "World"
        };
        var pieceIdx = 0;
        var mockFoo = new Mock<IFoo>();
        mockFoo.Setup(mk => mk.Bar()).Returns(()=>pieces[pieceIdx++]);
        var snafu = new Snafu(mockFoo.Object);
        Assert.AreEqual("Hello World", snafu.GetGreeting());
    }
