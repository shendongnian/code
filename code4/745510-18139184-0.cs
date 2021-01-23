    using (var context = new DataContext())
    {
        var item = context.Items.FirstOrDefault();
        var newBase = new ConcreteTwo()
        {
            Name = "Item 3", 
            User = new User { Name = "Foo" }
        };
        item.Base = newBase;
        context.SaveChanges();
    }
