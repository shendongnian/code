    [TestFixture]
    public class AutoFixtureTests
    {
        [Test]
        public void Can_Create_Class_With_Specific_Parameter_Value()
        {
            string wanted = "This is the first string";
            string wanted2 = "This is the second string";
            Fixture fixture = new Fixture();
            fixture.ConstructorArgumentFor<TestClass<string>, string>("value1", wanted)
                   .ConstructorArgumentFor<TestClass<string>, string>("value2", wanted2);
                
            TestClass<string> t = fixture.Create<TestClass<string>>();
            SimilarClass<string> s = fixture.Create<SimilarClass<string>>();
            Assert.AreEqual(wanted,t.Value1);
            Assert.AreEqual(wanted2,t.Value2);
            Assert.AreNotEqual(wanted,s.Value1);
            Assert.AreNotEqual(wanted2,s.Value2);
        }
        public class TestClass<T>
        {
            public TestClass(T value1, T value2)
            {
                Value1 = value1;
                Value2 = value2;
            }
            public T Value1 { get; private set; }
            public T Value2 { get; private set; }
        }
        public class SimilarClass<T>
        {
            public SimilarClass(T value1, T value2)
            {
                Value1 = value1;
                Value2 = value2;
            }
            public T Value1 { get; private set; }
            public T Value2 { get; private set; }
        }
    }
