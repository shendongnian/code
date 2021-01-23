    class Class1
    {
        private void Method1()
        {
            Type t = typeof(Class1);
            var obj = new TestClass(t);
            obj.TestMethod1();
        }
    }
    class TestClass
    {
        private Type _caller;
        public TestClass(Type type)
        {
            _caller = type;
        }
        public void TestMethod1()
        {
            TestMethod2();
        }
        private void TestMethod2()
        {
            //Do something with the class
        }
    }
