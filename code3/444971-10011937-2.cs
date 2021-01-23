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
                this.handler.Handler(new ShipOrderCommand
                {
                    OrderId = orderId,
                    ShippingInfo = info
                });
            }
        }
