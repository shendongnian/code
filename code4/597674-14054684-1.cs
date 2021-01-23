    public class Foo
    {
        public Foo() { }
        public void FooMethod(string parm) { }
    }
    public class Facilitator
    {
        public void RaiseAction(string type, string action, params object[] parm)
        {
            var o = Activator.CreateInstance("MyAssembly", type);
            var methodInfo = o.GetType().GetMethod(action);
            if (methodInfo == null) { return; }
            methodInfo.Invoke(o, parm);
        }
    }
