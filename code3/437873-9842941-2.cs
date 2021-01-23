    // Changed customer name
    var customer = new Customer { Id = customerId, Name = "Jim" };
    ctx.Customers.Attach(customer);
    // Load original SubObject from database
    ctx.Entry(customer).Reference(c => c.SubObject).Load();
    // Changed reference to another subobject
    var subObject2 = ctx.SubObjects.Find(subObject2Id);
    customer.SubObject = subObject2;
    ctx.Entry(customer).State = EntityState.Modified;
    ctx.SaveChanges();
    // No exception here.
