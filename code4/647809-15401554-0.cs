    _dbContext.Table1.AddObject(object1);
    _dbContext.Table2.AddObject(object2);
    _dbContext.Table3.AddObject(object3);
    _dbContext.Table4.AddObject(object4);
    _dbContext.Table5.AddObject(object5);
    _dbContext.SaveChanges(); // if fails will roll back all objects
