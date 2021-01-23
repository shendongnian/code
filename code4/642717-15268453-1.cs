    (var context = DataObjectFactory.CreateContext())
    {
        context.Customers.Add(entity);
        var group = context.CustomerGroups.Find(2); // or however you retrieve the existing group
        group.Customers.Add(entity);
        context.SaveChanges();
        return entity.Id
    }
