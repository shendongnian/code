    abstract class Parent
    {
        protected abstract object StaticLock { get; }
        public void Method()
        {
            lock(staticLock)
            {
                MethodImpl();
            }
        }
        protected abstract MethodImpl();
    }
    class Child1 : Parent
    {
        private static object staticLock = new object();
        protected override object StaticLock { get { return staticLock; } }
        protected override MethodImpl()
        {
              // Do something ...
        }
    }
    class Child2 : Parent
    {
        private static object staticLock = new object();
        protected override object StaticLock { get { return staticLock; } }
        protected override MethodImpl()
        {
              // Do something else ...
        }
    }
