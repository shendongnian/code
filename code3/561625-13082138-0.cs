    [TestFixture]
        public class Tests
        {    
            static class MyClass<T>
            {
                public static List<int> Member = new List<int>();
            }
    
            [Test]
            public void StaticTest()
            {
                var m1 = MyClass<int>.Member;
                var m2 = MyClass<string>.Member;
    
                Assert.AreNotSame(m1, m2);
            }
    }
