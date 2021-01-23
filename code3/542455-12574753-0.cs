    public static string insertQuery(string sql)
    {
        string connetionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Documents and Settings\Owner\Desktop\Arbeit\TrademarkParserproject1\TrademarkParserproject\bin\x86\Debug\Database.accdb";
        using(var oledbAdapter = new OleDbDataAdapter())
        using(var connection = new OleDbConnection(connetionString))
        {
            string success = "false";
            try
            {
                connection.Open();
                oledbAdapter.InsertCommand = new OleDbCommand(sql, connection);
                oledbAdapter.InsertCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                success = ex.ToString();
                return success;
            }
            success = "true";
            return success;
        }
    }
