    public ConnectedMySqlDataReader GetRecord(string query)
    {
        return new ConnectedMySqlDataReader(connectionString, query);
    }
    // ...
    var sql = "SELECT * FROM `table`";
    using(var dr = objDB.GetRecord(sql))
    {
        if (dr.Read())
        {
            // some code goes hear
        } 
     }
