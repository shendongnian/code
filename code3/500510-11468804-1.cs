    using (MyEntities context = new MyEntities())
    {
    var table1 =  new Table1()
    {
          StringColumn1 = "some value",
          StringColumn2 = "some value"
    };
    
        context.Table1.AddObject(table1);
    
        context.SaveChanges();
    
    int id = table1.Id;
    }
