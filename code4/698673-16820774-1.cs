    class CommandDispatcher
    {
        private readonly Autofac.IComponentContext context; // inject this
        public void Dispatch<TCommand>(TCommand command)
        {
            var handlers = context.Resolve<IEnumerable<ICommandHandler<TCommand>>>();
            foreach (var handler in handlers)
            {
                handler.Handle(command);
            }
        }
    }
