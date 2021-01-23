        public class ShipOrderCommandHandler 
            : ICommandHandler<ShipOrderCommand>
        {
            private readonly IRepository<Order> repository;
            public ShipOrderCommandHandler(
                IRepository<Order> repository)
            {
                this.repository = repository;
            }
            public void Handle(ShipOrderCommand command)
            {
                // do some useful stuf with the command and repository.
            }
        }
