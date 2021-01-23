    TestEntities db = new TestEntities();
    Test ts = (from rows in db.Tests
               where rows.ID == 1
               select rows).FirstOrDefault();
    if(ts != null)
    {
         db.Tests.DeleteObject(ts);
         db.SaveChanges();
    }
