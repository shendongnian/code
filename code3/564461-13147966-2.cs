    public class AsyncCommandHandlerDecorator<TCommand> 
        : ICommandHandler<TCommand> where TCommand : ICommand 
    {
        private readonly Container _container;
        private readonly Func<ICommandHandler<TCommand>> _factory;
        public AsyncCommandHandlerDecorator(Container container,
            Func<ICommandHandler<TCommand>> factory) 
        {
            _container = container;
            _factory = factory;
        }
        public void Handle(TCommand command) 
        {
            ThreadPool.QueueUserWorkItem(_ => 
            {
                using (_container.BeginLifetimeScope())
                {
                    // Create new handler in this thread
                    // and inside the lifetime scope.
                    var handler = _factory();
                    handler.Handle(command);
                }
            });
        }
    }
