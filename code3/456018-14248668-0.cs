    public interface IInterceptedMethods
    {
        void MethodA();
    }
    public interface IMyClass
    {
        void MethodA();
        void MethodB();
    }
    public class MyInterceptedMethods : IInterceptedMethods
    {
        [Loggable]
        public virtual void MethodA()
        {
            //Do stuff
        }
    }
    public class MyClass : IMyClass
    {
        private IInterceptedMethods _IInterceptedMethods;
        public MyClass(IInterceptedMethods InterceptedMethods)
        {
            this._IInterceptedMethods = InterceptedMethods;
        }
        public MethodA()
        {
            this._IInterceptedMethods.MethodA();
        }
        public Method()
        {
            //Do stuff, but don't get intercepted
        }
    }
