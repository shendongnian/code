    public class WcfFaultsCommandHandlerDecorator<TCommand>
        : ICommandHandler<TCommand>
    {
        private ICommandHandler<TCommand> decoratedHandler;
        public WcfFaultsCommandHandlerDecorator(
            ICommandHandler<TCommand> decoratedHandler)
        {
            this.decoratedHandler = decoratedHandler;
        }
        public void Handle(TCommand command)
        {
            try
            {
                this.decoratedHandler.Handle(command);
            }
            catch (ValidationException ex)
            {
                // Allows WCF to communicate the validation 
                // exception back to the client.
                throw new FaultException<ValidationResults>(
                    ex.ValidationResults);
            }
        }
    }
