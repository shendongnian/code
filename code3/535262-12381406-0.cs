    public class Container : IContainer
    {
        private IFoo _foo;
        private IBar _bar;
        private IBaz _baz;
        public Container(IContainerDependencies dependencies)
        {
            _foo = dependencies.Foo;
            _bar = dependencies.Bar;
            _baz = dependencies.Baz;
        }
    }
    public class ContainerDependencies : IContainerDependencies
    {
        public ContainerDependencies(IFoo foo, IBar bar, IBaz baz)
        {
            Foo = foo;
            Bar = bar;
            Baz = baz;
        }
        public IFoo Foo { get; set; }
        public IBar Bar { get; set; }
        public IBaz Baz { get; set; }
    }
    public interface IContainerDependencies
    {
        IFoo Foo { get; set; }
        IBar Bar { get; set; }
        IBaz Baz { get; set; }
    }
