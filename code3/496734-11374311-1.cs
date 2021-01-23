    public bool updateCMStable(int id, string columnName, string columnText) 
    { 
        columnText = columnText.Replace("'", "''");
        string sql = string.Format("UPDATE CMStable SET {0} = '{1}' WHERE cmsID={2}", 
            columnName, 
            columnText, 
            id); 
        int i = SqlHelper.ExecuteNonQuery(Connection.ConnectionString, CommandType.Text, sql); 
        return (i > 0); 
    }
