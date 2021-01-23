     var id = Guid.NewGuid();
        
     // insert
     using (var db = new EfContext("name=EfSample"))
     {
        var customers = db.Set<Customer>();
        customers.Add( new Customer { CustomerId = id, Name = "John Doe" } );
      
        db.SaveChanges();
     }
