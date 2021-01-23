    using (var context = DataObjectFactory.CreateContext())
    {
        entity.CustomerGroups = new List<CustomerGroup> { GroupName = "Foo bar" };
        context.Customers.Add(entity);
        context.SaveChanges();
        return entity.Id;
    }
