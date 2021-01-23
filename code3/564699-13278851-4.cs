    [UnitOfWorkAttribute]
    public View MoveCustomer(int customerId, Address address)
    {
        try
        {
            this.customerService.MoveCustomer(customerId, address);
        }
        catch { }
        return View();
    }
