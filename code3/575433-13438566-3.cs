    public class CreateValidFriendlyUrlCommandHandler<TCommand>
        : ICommandHandler<CreateProductCommand>
    {
        private readonly ICommandHandler<TCommand> decorated;
        public CreateValidFriendlyUrlCommandHandler(
            ICommandHandler<TCommand> decorated)
        {
            this.decorated = decorated;
        }
        public void Handle(CreateProductCommand command)
        {
            // This won't compile since CreateProductCommand and
            // TCommand are not related.
            this.decorated.Handle(command);
        }
    }
