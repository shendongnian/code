    Customer c;
    using(var context = new MyEntityContext())
    {
      c = context.Customer.FirstOrDefault(); //state is now Unchanged
      c.Name = "new name"; // this set the State to Modified
     //context.SaveChanges(); // will persist the data to the store, and set the State back to unchaged
    }
    //if we look at our customer outside the scope of our context
    //it's State will be Detacth
    Console.WriteLine(c.State);
