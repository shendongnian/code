        [Test]
        public void Test_UnboxingAtRuntime()
        {
            object str = "Hello";
            var s = DoSomething(str);
            Assert.That(s, Is.EqualTo("System.String"));
        }
        public string DoSomething(dynamic t)
        {
            return GetTypeName(t);
        }
        public string GetTypeName<T>(T obj)
        {
            return typeof (T).FullName;
        }
