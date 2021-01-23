    var kernel = new StandardKernel();
    ...
    kernel.Bind<Foo>().ToSelf().InSingletonScope();
    kernel.Bind<IFoo>().ToMethod(context => context.Kernel.Get<Foo>());
    ...
    // Controllers ask for the dependency as usual...
    public class SomeController : ApiController
    {
        readonly IFoo _foo;
    
        public SomeController(IFoo foo)
        {
            _foo = foo;
        }
    ...
