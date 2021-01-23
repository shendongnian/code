    private readonly ICommandHandler<MoveCustomerCommand> handler;
    // constructor
    public CustomerController(
        ICommandHandler<MoveCustomerCommand> handler)
    {
        this.handler = handler;
    }
    public View MoveCustomer(int customerId, Address address)
    {
        var command = new MoveCustomerCommand
        {
            CustomerId = customerId,
            Address = address,
        };
        this.handler.Handle(command);
        return View();
    }
