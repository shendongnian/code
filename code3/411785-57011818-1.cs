    [TestFixture]
    public class UnitTests : ObjectWithPrivateMethods
    {
        [Test]
        public void TestSomeProtectedMethod()
        {
            Assert.IsTrue(this.SomeProtectedMethod() == true, "Failed test, result false");
        }
    }
