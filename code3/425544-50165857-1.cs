        public class WindsorSimpleHandler : IHandler
    {
        public object TheValue { get; set; }
        public ComponentModel ComponentModel { get; set; }
        public HandlerState CurrentState { get; set; }
        public bool CanResolve(CreationContext context, ISubDependencyResolver contextHandlerResolver, ComponentModel model,
            DependencyModel dependency)
        {
            return true;
        }
        public object Resolve(CreationContext context, ISubDependencyResolver contextHandlerResolver, ComponentModel model,
            DependencyModel dependency)
        {
            return TheValue;
        }
        public object Resolve(CreationContext context)
        {
            return TheValue;
        }...
