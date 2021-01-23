        protected override IController GetControllerInstance(
            RequestContext requestContext, Type controllerType)
        {
            if (controllerType == typeof(ShipOrderController))
            {
                return new ShipOrderController(
                    new TransactionalCommandHandlerDecorator<ShipOrderCommand>(
                        new ShipOrderCommandHandler(
                            new OrderRepository())));
            }
            return base.GetControllerInstance(requestContext, controllerType);
        }
