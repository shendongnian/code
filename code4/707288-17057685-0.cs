    public bool isAdmin(string username)
    {
        // Create connection object
        OleDbConnection oleConn = new OleDbConnection(connString);
        oleConn.Open();
        string sql = "SELECT [admin] FROM [Users] WHERE [username]='" + username + "'";
        OleDbCommand cmd = new OleDbCommand(sql, oleConn);
        bool x = (bool)cmd.ExecuteScalar();
        oleConn.Close();
        return x;
    }
