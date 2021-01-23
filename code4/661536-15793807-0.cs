    using (MyEntities dbContext = new MyEntities())
    {
      Info x = new Info();
    
      dbContext.YourTableObjectSet.AddObject(x);
    }
