    public class SomeClass : IB
    {
        public IMyClass<A> SomeGetter
        {
            get { return new MyClass<A>(); }
        }
    }
