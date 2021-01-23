    Person thePerson = new Person {PersonID = Id}; // Id is either previously fetched or a newly created one
    foreach (var order in orders)
    {
       context.Orders.AddObject(new Order
       {
          Price = order.Price,
          Item = order.ItemName,
          Person = thePerson
       });
    }
    context.SaveChanges();
