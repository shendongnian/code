    public int AddCustomer(Customer customer)
    {
        using (var context = DataObjectFactory.CreateContext())
        {
            var customerEntity = Mapper.Map(customer);
            context.AddObject("CustomerEntities", customerEntity);
    
            context.SaveChanges();
    
            return customerEntity.Id;
        }
    }
