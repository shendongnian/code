    public void SomeOperation()
    {
        using (var db = new somethingEntities())
        {
            foreach (var item in db.BuildSet<SimpleSet>())
            {
                //do something with item
                //SaveChanges() every 100 rows or whatever
            }
        }
    }
