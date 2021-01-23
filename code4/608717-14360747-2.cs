    string connectionString = GetSqlConnectionString();
    using (MyEntities entities = new MyEntities(connectionString))
    {
      MyDataEntity myDataEntity = new MyDataEntity();
    
      // Save to the database
      entities.MyDataEntity.Add(myDataEntity);
      entities.SaveChanges();
    }
