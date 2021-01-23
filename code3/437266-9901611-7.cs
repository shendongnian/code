    public class DecoratorCommandHandler<TCommand>
        : ICommandHandler<TCommand>
    {
        private ICommandHandler<TCommand> inner;
        public DecoratorCommandHandler(
            ICommandHandler<TCommand> inner)
        {
            this.inner = inner;
        }
        public virtual void Handle(TCommand command)
        {
             this.inner.Handle(command);
        }
    }
