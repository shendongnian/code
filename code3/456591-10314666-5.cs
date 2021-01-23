    using (var db=new SomeDatabaseContext())
    {
         db.SomeTable
           .Where(x=>ls.Contains(x.friendid))
           .ToList()
           .ForEach(a=>a.status=true);
         db.SubmitChanges();
    }
