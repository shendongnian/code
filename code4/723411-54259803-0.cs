    var x = new MyEntity();        // x.Id = 0
    dbContext.Add(x);              // x.Id = -2147482624 <-- EF Core generated id
    var y = new MyOtherEntity();   // y.Id = 0
    dbContext.Add(y);              // y.Id = -2147482623 <-- EF Core generated id
    y.MyEntityId = x.Id;           // y.MyEntityId = -2147482624
    dbContext.SaveChangesAsync();
    Debug.WriteLine(x.Id);         // 1261 <- EF Core replaced temp id with "real" id
    Debug.WriteLine(y.MyEntityId); // 1261 <- reference also adjusted by EF Core
   
