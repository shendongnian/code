    public class FooProxy : IFoo
    {
        private readonly FooA a;
        private readonly FooB b;
        public FooProxy(FooA a, FooB b)
        {
            this.a = a;
            this.b = b;
        }
        void IFoo.SomeFooMethod()
        {
            this.GetFooBasedOnSomeCondition().SomeFooMethod();
        }
        private IFoo GetFooBasedOnSomeCondition()
        {
            return condition ? this.a : this.b;
        }
    }
