    IQueryable<MyTable> myTableQuery = context.MyTables.AsQueryable();
    if (parameter1 != 0)
    {
        IQueryable<OtherTable> otherTableQuery = context.OtherTables.AsQueryable();
        if (parameter2 != 0)
        {
            otherTableQuery = otherTableQuery.Where(ot => OtherValue = parameter2);
        }
        myTableQuery = myTableQuery.Where(mt => otherTableQuery.Any(ot => ot.Id = mt.Id));
    }
    return myTableQuery.ToList();
