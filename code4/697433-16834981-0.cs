    using (MyEntities dataContext = new MyEntities())
        {
          var query = (from q in dataContext.Queries
                         where q.Query_Name == queryName
                         select q.Query).Single();
          queryResults = dataContext.ExecuteStoreQuery<string>(query);
          List<string> list = new List<string>(queryResults.ToArray<string>());
          return list; }
