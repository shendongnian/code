    MyTable result;
    if(........)
    {
        result = DBContext.MyTables.SingleOrDefault(x => x.ID == 1);
    }
    else
    {
        result = DBContext.MyTables.SingleOrDefault(x => x.ID == 2);
    }
