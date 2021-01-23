    protected void Form_Load()
    {
        string connstring = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\mydatabase.mdb;User Id=admin;Password=;";
        string sql = "insert into tblYourData (field1, field2) values ('some text', 'some more text')";
        CreateCommand(sql, connstring);
    }
    private static void CreateCommand(string queryString, string connectionString)
    {
        using (OleDbConnection connection = new OleDbConnection(
                   connectionString))
        {
            OleDbCommand command = new OleDbCommand(queryString, connection);
            command.Connection.Open();
            command.ExecuteNonQuery();
        }
    }
