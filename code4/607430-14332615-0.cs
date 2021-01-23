    [TestFixture]
    public class Tests
    {
        [Test]
        public void Test()
        {
            var obj = new MyClass();
            obj.First = "some value";
            obj.Second = "some value";
            obj.Third = "some value";
            AssertPropertyValues(obj, "some value", x => x.First, x => x.Second, x => x.Third);
        }
        private void AssertPropertyValues<T, TProp>(T obj, TProp expectedValue, params Func<T, TProp>[] properties)
        {
            foreach (var property in properties)
            {
                TProp actualValue = property(obj);
                Assert.AreEqual(expectedValue, actualValue);
            }
        }
    }
