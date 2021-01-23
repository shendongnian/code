    // perform the copy
    var copy = AutoMapper.Mapper.Map<MyObject, MyObject>(original);
    /* make copy updates here */
    // evicts everything from the current NHibernate session
    mySession.Clear();
    // saves the entity
    mySession.Save(copy); // mySession.Merge(copy); can also work, depending on the situation
