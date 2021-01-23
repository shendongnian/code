    [ServiceContract]
    class MyService
    {
      private MyEntities db = new MyEntities();
      [OperationContract]
      public void Save(MyObject entity)
      {
        this.db.MyObjects.Add(entity);
        this.db.SaveChanges();
      }
      [OperationContract]
      public MyObjectFind(Int32 id)
      {
        return this.db.MyObjects.Single(x => x.Id == id);
      }
    }
