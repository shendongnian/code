    public class DecoratedHandler<TCommand> : DecoratorCommandHandler<TCommand>
    {
        public DecoratedHandler(UnityContainer container)
            : base(BuildInner(container))
        {
        }
        private static ICommandHandler<TCommand> BuildInner(UnityContainer container)
        {
             var handlerContainer = container.Resolve<UnityContainer>("Handlers");
             var commandHandler = handlerContainer.Resolve<ICommandHandler<TCommand>>();
             var inner = new TryCatchCommandHandler<TCommand>(commandHandler);
             return inner;
        }
    }
