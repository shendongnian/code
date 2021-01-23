        DataTable schemaTable = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables,
                                                           new object[] {null, null, null, "TABLE"});
    
    //Get the First Sheet Name
            string firstSheetName = schemaTable.Rows[0][2].ToString(); 
    
            //Query String 
            string sql = string.Format("SELECT * FROM [{0}],firstSheetName); 
