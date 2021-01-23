    //context is an injected IDbContext:
    var contact = context.EntitySet<Contact>().Single(x => x.Id = 2);    
    contact.Name = "Updated name";
    context.EntitySet<Contact>().Add(new Contact { Name = "Brand new" });
    context.SaveChanges();
    
