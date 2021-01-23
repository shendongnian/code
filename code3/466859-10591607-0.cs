    public IList<MyObj> GetPagedData(string filter, string sort, int skip, int take)
    {
       using(var db = new DataContext())
       {
          var q = GetDataInternal(db);
          if(!String.IsNullOrEmpty(filter))
             q = q.Where(filter); //Using Dynamic linq
         
          if(!String.IsNullOrEmpty(sort))
             q = q.OrderBy(sort); //And here
    
          return q.Skip(skip).Take(take).ToList();
       }
    }
    
    public int GetTotalCount(string filter)
    {
        using(var db = new DataContext())
        {
           var q = GetDataInternal(db);
           if(!String.IsNullOrEmpty(filter))
             q = q.Where(filter); //Using Dynamic linq
    
           return q.Count(); //Without ordering and paging.
        }
    }
    
    private static IQuerable<MyObj> GetDataInternal(DataContext db)
    {
       return 
            from x in db.JournalEventsView 
            where ...
            select new ...;
    }
