    string connStr = string.Format("user={0};password={1};database={2}",
                                    username,password,database);
    List<string>TableNames = new List<string>();//Stores table names in List<string> form
    using(MySqlConnection Conn = new MySqlConnection(connStr))
    {
        Conn.Open();
        string cmdStr = "show tables";
        TableNames = MySqlCollectionQuery(Conn,cmdStr);
    }
