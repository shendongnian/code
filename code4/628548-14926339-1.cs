    string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fileName +
        ";Mode=ReadWrite;Extended Properties=\"Excel 12.0 XML;HDR=NO\"";
    using (OleDbConnection conn = new OleDbConnection(connectionString))
    {
        conn.Open();
        using (OleDbCommand cmd = new OleDbCommand())
        {
            cmd.Connection = conn;
            cmd.CommandText = "CREATE TABLE [MySheet] (<colname> <col type>)";  // Doesn't matter what the field is called
            cmd.ExecuteNonQuery();
            cmd.CommandText = "UPDATE [MySheet$] SET F1 = \"\"";
            cmd.ExecuteNonQuery();
        }
        conn.Close();
    }
