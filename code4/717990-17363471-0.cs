    MyTable result;
    if(........)
    {
        result = DBContext.MyTables.Where(x => x.ID == 1).SingleOrDefault();
    }
    else
    {
        result = DBContext.MyTables.Where(x => x.ID == 2).SingleOrDefault();
    }
