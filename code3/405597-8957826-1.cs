    [TestFixture]
    public class FooTest
    {
        [Test]
        public void Bar()
        {
            var foo = (IFoo)null;  //At this point I use Resharper to create IFoo interface
    
            Assert.IsTrue(foo.Bar()); //At this point I use Resharper to create bool IFoo.Bar();
        }
    }
