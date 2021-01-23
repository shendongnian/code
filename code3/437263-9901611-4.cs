    public class DecoratorCommandHandler<TCommand>
        : ICommandHandler<TCommand>
    {
        private ICommandHandler<TCommand> _Inner;
        public DecoratorCommandHandler(
            ICommandHandler<TCommand> inner)
        {
            this._Inner = inner;
        }
        public virtual void Handle(TCommand command)
        {
             this._Inner.Handle(command);
        }
    }
