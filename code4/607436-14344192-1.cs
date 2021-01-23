    [TestFixture]
    public class MyTest
    {
        private TestCaseData[] propertyCases = new[]
            {
                new TestCaseData(
                    "First",
                    (Func<MyClass, string>) (obj => obj.First),
                    (Action<MyClass, string>) ((obj, newVal) => obj.First = newVal)),
                new TestCaseData(
                    "Second",
                    (Func<MyClass, string>) (obj => obj.Second),
                    (Action<MyClass, string>) ((obj, newVal) => obj.Second = newVal)),
                new TestCaseData(
                    "Third",
                    (Func<MyClass, string>) (obj => obj.Third),
                    (Action<MyClass, string>) ((obj, newVal) => obj.Third = newVal))
            };
        [Test]
        [TestCaseSource("propertyCases")]
        public void Test(string description, Func<MyClass, string> getter, Action<MyClass, string> setter)
        {
            var obj = new MyClass();
            setter(obj, "42");
            var actual = getter(obj);
            Assert.That(actual, Is.EqualTo("42"));
        }
    }
