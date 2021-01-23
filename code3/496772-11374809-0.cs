    using(SQLiteConnection sqlConn = new SQLiteConnection("Data Source=" + m_dbName))
    {
        sqlConn.Open();
        //create command
        
        SQLiteDataAdapter sqlAdapter = new SQLiteDataAdapter { DeleteCommand = sqlComm };
        sqlAdapter.Update();
    }
