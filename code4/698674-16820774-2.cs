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
        public void ReflectionDispatch(ICommand command)
        {
            Action<CommandDispatcher, ICommand> action = BuildAction(command.GetType());
            // see link below for an idea of how to implement BuildAction
            action(this, command);
        }
    }
