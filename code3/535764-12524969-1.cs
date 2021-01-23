    [Given("a customer named (.*)")]
    public void GivenACustomer(string customerName)
    {
      _customerDriver.CreateCustomer(customerName);
    }
    
    
    [Given("an empty schedule for the customer (.*)")]
    public void GivenEmptySchedule(string customerName)
    {
      var customer = _customerDriver.GetCustomer(customerName);
      _scheduleDriver.CreateForCustomer(customer);
    }
