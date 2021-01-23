        public ShipOrderController : Controller
        {
            private readonly ICommandHandler<ShipOrderCommand> handler;
            public ShipOrderController(
                ICommandHandler<ShipOrderCommand> handler)
            {
                this.handler = handler;
            }
            public void Ship(int orderId, ShippingInfo info)
            {
                this.handler.Handle(new ShipOrderCommand
                {
                    OrderId = orderId,
                    Info = info
                });
            }
        }
