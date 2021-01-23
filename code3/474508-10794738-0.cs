    public ActionResult ListCustomers(int id)
    {
        IEnumerable<Customer> customers = Retrieve(id);
        ...
    }
