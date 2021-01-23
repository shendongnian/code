You can use [TransactionScope][1] to simulate DB access, but not committing the actual changes to the database. Something like this:
    [TestMethod]
    public void AddingShouldWork()
    {
        using (var transaction = new TransactionScope())
        {
            var repository = new ICustomerRepository<Customer>();
            var customer = new Customer();
            customer.Name = "OEM Computers Inc.";
            repository.Add(customer);
        }
    }
By not calling transaction.Complete() the operations are treated just like a rollback, resulting in no database insert. This is just the behaviour you want for unit (not integration) testing. You can also use `Moq<Customer>` to not create real entities.
