    public void Update(string task, string dbPath, string colName, string tableName = "Frames") 
    { 
        using(OleDbConnection db = new OleDbConnection("........"))
        {
            db.Open(); 
            var schema = db.GetSchema("COLUMNS"); 
            var col = schema.Select("TABLE_NAME='" + tableName + 
                       " AND COLUMN_NAME='" + colName + "'" 
 
            if(col.Length > 0)
               // Column exist
            else
               // Column doesn't exist
    } 
