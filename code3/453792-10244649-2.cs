    using (interfaceDB DB = new DB1())
    {
        var getTable1A = (from a in DB.a select a).Cast<ICommonStuff>();
    }
    using (interface DB = new DB2())
    {
        var getTable2A = (from a in DB.a select a).Cast<ICommonStuff>();
    }
    using (interface DB = new DB3())
    {
        var getTable3A = (from a in DB.a select a).Cast<ICommonStuff>();
    }
    var everythingLikeA = getTable1A.Concat(getTable2A).Concat(getTable3A);
    foreach (ICommonStuff commonStuff in everythingLikeA)
    {
        // do something here with commonStuff.CommonInt and commonStuff.CommonString
    }
