    container.Register(Component.For<IFoo>().ImplementedBy<Foo>().LifeStyle.Transient);
    container.Kernel.Resolver.AddSubResolver(new LoggerResolver(container.Kernel));
    public class LoggerResolver : ISubDependencyResolver
    {
        ...
    
        public object Resolve(CreationContext context, ISubDependencyResolver contextHandlerResolver, ComponentModel model, DependencyModel dependency)
        {
            //No need to can resolve, Windsor will do this for you
            return new CommonLog(model.Implementation);
        }
    }
