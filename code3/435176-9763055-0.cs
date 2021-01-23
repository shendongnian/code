        using (var context = new XXEntities())
        {
          //context.Customers.AddObject(customer);
            context.Customers.Attach(customer);  
            context.SaveChanges();
        }
