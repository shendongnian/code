    public class TestClass
    {
        public TestClass(Action method)
        {
            MethodToCall = method;
            method();
        }
    
        public Action MethodToCall { get; set; }
    }
    
    public class TestDelegate
    {
        public TestDelegate()
        {
            // Uses lambda syntax to create a closure that will be represented in
            // a delegate object and passed to the TestClass constructor.
            TestClass tc = new TestClass(() => DoSomething("blabla", 123, null));
        }
    
        private void DoSomething(string aString, int anInt, object somethingElse)
        {
            // ...
        }
    }
