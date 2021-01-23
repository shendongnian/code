    public class CreateValidFriendlyUrlCommandHandler
        : ICommandHandler<CreateProductCommand>
    {
        private ICommandHandler<CreateProductCommand> decorated;
        public CreateValidFriendlyUrlCommandHandler(
            ICommandHandler<CreateProductCommand> decorated)
        {
            this.decorated = decorated;
        }
        public void Handle(CreateProductCommand command)
        {
            // logic here
        }
    }
