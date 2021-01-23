    string connectionString = GetUsersConnectionString();
    using (MyEntities entities = new MyEntities(new EntityConnection(connectionString )))
    {
      MyDataEntity myDataEntity = new MyDataEntity();
      // Save to the database
      entities.MyDataEntity.Add(myDataEntity);
      entities.SaveChanges();
    }
