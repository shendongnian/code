    public class FooComposite : IFoo
    {
        private readonly Func<IFoo>[] fooFactories;
        public FooComposite(params Func<IFoo>[] fooFactories)
        {
            this.fooFactories = fooFactories.ToArray();
        }
        void IFoo.FooThatThing(IBar bar)
        {
            foreach (var fooFactory in this.fooFactories)
            {
                var foo = fooFactory();
                foo.FooThatThing(bar);
            }
        }
    }
