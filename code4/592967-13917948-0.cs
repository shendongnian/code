    var db = new NorthwindDataContext();
    // Create a new Order object.
    Order ord = new Order
    {
        OrderID = 12000,
        ShipCity = "Seattle",
        OrderDate = DateTime.Now
        // …
    };
    
    // Add the new object to the Orders collection.
    db.Orders.InsertOnSubmit(ord);
    
    // Submit the change to the database.
    try
    {
        db.SubmitChanges();
    }
    catch (Exception e)
    {
        Console.WriteLine(e);
        // Make some adjustments.
        // ...
        // Try again.
        db.SubmitChanges();
    }
