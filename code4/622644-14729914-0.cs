    string sql = "select listid from list where ShortDesc='Master'";
    SqlCeCommand cmdGetOldMasterId = new SqlCeCommand(sql, DbConnection.ceConnection);
    SqlCeDataReader reader = cmdGetOldMasterId.ExecuteReader();
    while(reader.Read())
    {
        Console.WriteLine(reader[0].ToString());
        // or, if your listid is an integer  
        // int listID = reader.GetInt32(0);   
    }
