    public class LifetimeScopedCommandHandlerDecorator<TCommand> 
        : ICommandHandler<TCommand> where TCommand : ICommand 
    {
        private readonly Container _container;
        private readonly Func<ICommandHandler<TCommand>> _factory;
        public LifetimeScopedCommandHandlerDecorator(Container container,
            Func<ICommandHandler<TCommand>> factory)
        {
            _container = container;
            _factory = factory;
        }
        public void Handle(TCommand command)
        {
            using (_container.BeginLifetimeScope())
            {
                // The handler must be created inside the lifetime scope.
                var handler = _factory();
                handler.Handle(command);
            }
        }
    }
