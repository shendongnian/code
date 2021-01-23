    IQueryOver<Table1, Table2> myQuery = 
      session.QueryOver<Table1>()
       .Left.JoinQueryOver<Table2>(t => t.Table2s)
         .Where(
           Restrictions.Or(
             Restrictions.On<Table2>((t2) => t2.ID).IsNull, 
             Restrictions.On<Table2>((t2) => t2.Field).IsLike("value")
             )
           );
    var list = myQuery.List<Table1>();
