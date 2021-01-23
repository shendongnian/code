       public virtual IQueryable<T> GetTable<T, A>(string table1Variable,
                                            string table2Variable) 
                                                      where T : class
                                                      where A : class
        {
            var table1 = entityDatabaseDC.GetTable<T>();
            var table2 = entityDatabaseDC.GetTable<A>();
    
            return from entity in table1.AsQueryable()
                   join entity2 in table2 on 
                   entity.GetType().GetProperty(table1Variable).GetValue(table1,null)
                                          equals 
                   entity2.GetType().GetProperty(table2Variable).GetValue(table2,null)
                   select entity;
    
        }
