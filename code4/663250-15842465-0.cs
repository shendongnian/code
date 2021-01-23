    public class TestDelegate
    {
        public TestDelegate()
        {
            TestClass tc = new TestClass(() => DoSomething("blabla", 123, null));
        }
    
        private void DoSomething(string aString, int anInt, object somethingElse)
        {
            ...
        }
    }
    
    public class TestClass
    {
        public TestClass(Action method)
        {
            this.MethodToCall = method;
            this.MethodToCall.Invoke();
        }
    
        // Do you really need this to be writable?
        public Action MethodToCall { get; set; }
    }
