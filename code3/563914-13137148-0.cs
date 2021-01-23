    Dictionary<string, object> searchList = new Dictionary<string, object>();
    searchList.Add("LastName", "Foo");
    searchList.Add("FirstName", "Bar");
    searchList.Add("Id", 42); // yep, not only strings
    var conditions = searchList.Select((kvp, i) => String.Format("{0} = @{1}", kvp.Key, i));
    string predicate = String.Join(" and ", conditions);
    object[] values = searchList.Select(kvp => kvp.Value).ToArray();
    var query = _dbSet.Where(predicate, values);
