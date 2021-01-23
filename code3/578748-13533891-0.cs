    private void Initialize(string fileName, string tableName)
    {
        string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fileName + ";Mode=ReadWrite;Extended Properties=\"Excel 8.0;HDR=NO\"";
        string fieldstring = "(ID int, Field1 char(255), Field2 char(255))";
        using (OleDbConnection conn = new OleDbConnection(connectionString))
        {
            conn.Open();
            
            using (OleDbCommand cmd = new OleDbCommand())
            {
                cmd.Connection = conn;
                cmd.CommandText = string.Format(CultureInfo.InvariantCulture, @"CREATE TABLE [{0}] {1}", tableName, fieldstring);
                cmd.ExecuteNonQuery();
            }
            conn.Close();
        }
    }
    public void InsertRow(string fileName, string tableName, string data)
    {
        string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fileName + ";Mode=ReadWrite;Extended Properties=\"Excel 8.0;HDR=YES\"";
        string headers = "ID,Field1,Field2";
        using (OleDbConnection conn = new OleDbConnection(connectionString))
        {
            conn.Open();
            using (OleDbCommand cmd = new OleDbCommand())
            {
                cmd.Connection = conn;
                cmd.CommandText = string.Format(CultureInfo.InvariantCulture, @"INSERT INTO [{0}$] ({1}) values({2})", tableName, headers, data);
                txtQuery.Text = cmd.CommandText;
                cmd.ExecuteNonQuery();
            }
            conn.Close();
        }
    }
