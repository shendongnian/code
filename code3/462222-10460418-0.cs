    private static void AttachDB(string fileDB, string aliasName, SQLiteConnection cn) 
    { 
        string sqlText = string.Format("ATTACH '{0}' AS {1}", fileDB, aliasName) 
        SQLiteCommand cmd = new SQLiteCommand(sqlText, cn) 
        cmd.ExecuteNonQuery(); 
    } 
