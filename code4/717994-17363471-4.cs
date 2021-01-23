    Func<MyTable, bool> condition;
    if (.....)
    {
        condition = x => x.ID == 1;
    }
    else
    {
        condition = x => x.ID == 2;
    }
    var emptyIQueryable =
             DBContext.MyTables
                      .Join(MyTableTwos, x => x.ID, i => i.TID, ((x,i) => new {x,i}))
                      .Where(condition).SingleOrDefault();
