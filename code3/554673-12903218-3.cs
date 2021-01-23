    System.Linq.Expressions.Expression<Func<SomeNeatEntity, bool>> func = x => x.DateCreated < System.Data.Objects.EntityFunctions.AddDays(DateTime.Now, -7);
    
    var entities = new MyEntities();
    
    var t = entities.SomeNeatEntities.Where(func);
    Console.WriteLine(t.Count());
    
    var h = entities.SomeNeatEntities.Where(x => x.SomeField != null).Where(func);
    Console.WriteLine(h.Count());
