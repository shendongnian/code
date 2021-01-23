    public bool updateCMStable(int id, string columnName, string columnText) 
    { 
       if(!string.IsNullOrEmpty))
       {
           switch(columnName)
           {
               // TODO: change 50 & 100 to the real sizes of your columns, 
               // and obviously the column names too...
               case "column1":
                   if(columnText.Length > 50)
                       columnText = columnText.SubString(0, 50);
                   break;
               case "column2":
                   if(columnText.Length > 100)
                       columnText = columnText.SubString(0, 100);
                   break;
               etc... 
            }
        }
        // replace single quote with double single quotes
        columnText = columnText.Replace("'", "''");
        string sql = string.Format("UPDATE CMStable SET {0} = '{1}' WHERE cmsID={2}", 
            columnName, 
            columnText, 
            id); 
        int i = SqlHelper.ExecuteNonQuery(Connection.ConnectionString, CommandType.Text, sql); 
        return (i > 0); 
    }
