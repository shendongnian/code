    [Authorize(Roles="Customer, Company")]
    public ActionResult ViewOrders(...)
    {
        ...
    }
    [Authorize(Roles="Customer")]
    public ActionResult CreateOrder(...)
    {
        ...
    }
