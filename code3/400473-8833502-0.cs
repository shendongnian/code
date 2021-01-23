    // A composite is something that implements an interface
    // (in this case IFoo) and wraps a coll
    public class FooComposite : IFoo
    {
        private readonly IEnumerable<IFoo> foos;
        public FooComposite(params IFoo[] foos)
        {
            this.foos = foos;
        }
        void IFoo.FooThatThing(IBar bar)
        {
            foreach (var foo in this.foos)
            {
                foo(bar);
            }
        }
    }
