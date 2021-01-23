    using (var context = DataObjectFactory.CreateContext())
    {
        var customerGroups = context.CustomerGroups.Where(...).ToList(); // get your CustomerGroup object(s) here, and ensure it's enumerated with ToList()
        entity.CustomerGroups = customerGroups;
        context.Customers.Add(entity);
        context.SaveChanges();
        return entity.Id;
    }
