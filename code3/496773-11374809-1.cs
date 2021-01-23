    using(SQLiteConnection sqlConn = new SQLiteConnection("Data Source=" + m_dbName))
    {
        sqlConn.Open();
        //create command
        
        sqlCommand.ExecuteNonQuery();
    }
