       public class CreateValidFriendlyUrlCommandHandler<TCommand>
            : ICommandHandler<TCommand>
            where TCommand : CreateProductCommand
        {
            private ICommandHandler<TCommand> decorated;
    
            public CreateValidFriendlyUrlCommandHandler(
                ICommandHandler<TCommand> decorated)
            {
                this.decorated = decorated;
            }
    
            public void Handle(TCommand command)
            {
                // logic here
            }
        }
