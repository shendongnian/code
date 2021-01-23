    public ActionResult GetCustomerList()
    {
      var customers=YourDataAccessClass.GetCustomers().ToList();
      return View(customers);
    }
