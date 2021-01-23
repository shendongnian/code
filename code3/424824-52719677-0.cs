    ExpandoObject param = new ExpandoObject();
    
    IDictionary<string, object> paramAsDict = param as IDictionary<string, object>;
    paramAsDict.Add("foo", 42);
    paramAsDict.Add("bar", "test");
    
    MyRecord stuff = connection.Query<MyRecord>(query, param);
