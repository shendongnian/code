    [OperationContract]
    public void Save(MyObject entity)
    {
      using (MyEntities db = new MyEntities())
      {
        db.MyObjects.Add(entity);
        db.SaveChanges();
      }
    }
    
    [OperationContract]
    public MyObject Single(Int32 id)
    {
      using (MyEntities db = new MyEntities())
      {
        return db.MyObjects.Single(x => x.Id == id);
      }
    }
