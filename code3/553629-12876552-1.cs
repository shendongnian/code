    [TestFixture]
    public class Tests {
        [TestCase("test1")]
        public void FooTest_One(String value) {
            Foo f = new Foo(value);
            Assert.IsTrue(f.TestOne());
            Assert.IsFalse(f.TestTwo());
        }
        [TestCase("test2")]
        public void FooTest_Two(String value) {
            Foo f = new Foo(value);
            Assert.IsTrue(f.TestTwo());
            Assert.IsFalse(f.TestOne());
        }
    }
