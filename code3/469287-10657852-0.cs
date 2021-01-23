    public CustomerRepository
    {
        public Customer GetCustomerFor(int customerId)
        {
            var tier1Obj = Tier1DBContext.Customers.First(x => x.CustomerId == customerId);
            var tier2Obj = Tier2DBContext.Customers.First(x => x.CustomerId == customerId);
            // merge them into some new object
            return mergedCustomerObject;
        }
    }
