    private void DoSomething()
    {
            var customer = new Customer
            {
                Status = CustomerStatus.Active
            };
            if (customer.Status.In(CustomerStatus.Active, CustomerStatus.Inactive))
            {
                // Do something.
            }
    }
