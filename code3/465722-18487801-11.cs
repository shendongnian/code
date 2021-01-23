    public class CommandLifetimeScopeDecorator<TCommand> : ICommandHandler<TCommand>
    {
        private readonly Func<ICommandHandler<TCommand>> _handlerFactory;
        private readonly Container _container;
        public CommandLifetimeScopeDecorator(
            Func<ICommandHandler<TCommand>> handlerFactory, Container container)
        {
            _handlerFactory = handlerFactory;
            _container = container;
        }
        [DebuggerStepThrough]
        public void Handle(TCommand command)
        {
            using (_container.BeginLifetimeScope())
            {
                var handler = _handlerFactory(); // resolve scoped dependencies
                handler.Handle(command);
            }
        }
    }
