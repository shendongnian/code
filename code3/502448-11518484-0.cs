    // List<T> implements IEnumerable
    var list = new List<MySqlParameter>();
    var paramCol = new MySqlParameterCollection();
    // Add parameters to list
    // ...
    // Assuming param collection set up
    paramCol.AddRange(list);
