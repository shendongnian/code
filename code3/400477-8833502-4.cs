    // A composite is something that implements an interface
    // (in this case IFoo) and wraps a list of items of that
    // same interface.
    public class FooComposite : IFoo
    {
        private readonly IEnumerable<IFoo> foos;
        public FooComposite(params IFoo[] foos)
        {
            this.foos = foos.ToArray();
        }
        void IFoo.FooThatThing(IBar bar)
        {
            foreach (var foo in this.foos)
            {
                foo.FooThatThing(bar);
            }
        }
    }
