    public int AddCustomer(Customer customer)
    {
        using (var context = DataObjectFactory.CreateContext())
        {
            var c= Mapper.Map(customer);
            context.AddObject("CustomerEntities", c);
    
            context.SaveChanges();
    
            return c.Id;
        }
    }
