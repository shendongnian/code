    public ActionResult Index()
    {
        IEnumerable<string> customers = new[] { "cust1", "cust2" };
        var values = new RouteValueDictionary(
            customers
                .Select((customer, index) => new { customer, index })
                .ToDictionary(
                    key => string.Format("[{0}]", key.index),
                    value => (object)value.customer
                )
        );
        return RedirectToAction("ListCustomers", values);
    }
    public ActionResult ListCustomers(IEnumerable<string> customers)
    {
        ...
    }
