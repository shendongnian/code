    Northwnd db = new Northwnd(@"c:\northwnd.mdf");
    
    var custQuery =
        from cust in db.Customers
        where cust.City == "London" 
        select cust;
    
    foreach (Customer custObj in custQuery)
    {
        Console.WriteLine("CustomerID: {0}", custObj.CustomerID);
        Console.WriteLine("\tOriginal value: {0}", custObj.City);
        custObj.City = "Paris";
        Console.WriteLine("\tUpdated value: {0}", custObj.City);
    }
    
    //get object modified 
    ChangeSet cs = db.GetChangeSet();
    Console.Write("Total changes: {0}", cs);
    // Freeze the console window.
    Console.ReadLine();
    
    db.SubmitChanges();
 
