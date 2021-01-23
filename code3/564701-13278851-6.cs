    public class MoveCustomerCommandHandler
        : ICommandHandler<MoveCustomerCommand>
    {
        private readonly IDataContext context;
        public MoveCustomerCommandHandler(IDataContext context)
        {
            this.context = context;
        }
        public void Handle(MoveCustomerCommand command)
        {
            // TODO: Put logic here.
        }
    }
