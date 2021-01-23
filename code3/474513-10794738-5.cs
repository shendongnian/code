    public ActionResult ListCustomers(int id)
    {
        IEnumerable<string> customers = Retrieve(id);
        ...
    }
