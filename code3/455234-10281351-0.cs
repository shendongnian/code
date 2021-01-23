    List<int> ids = new List<int>() { 0, 1, 3, 6 };
    filterEntities = (from list in filterEntities 
                      where ids.Contains(list.Id)
                      group list by list.id into g
                      orderby g.Key
                      select new 
                      {
                        ID = g.Key,
                        Age = g.Sum(x => x.Age),
                      }).ToList();
