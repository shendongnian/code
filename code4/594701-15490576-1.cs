    [WebGet]
    public IQueryable<Table> Query1()
    {
      var Context = new ProjectEntities();
            var First = new DateTime(2012, 10, 5, 8, 0, 0, 0);
            var Last = new DateTime(2012, 11, 5, 17, 0, 0, 0);
          return 
                Context.Table.Where(
                    s =>
                    s.Date > First && s.Date < Last &&
                    Context.Table2.FirstOrDefault(a => a.ID ==1).Table3.Contains(s.Table3)).Take(20).AsQueryable();
    
    }
