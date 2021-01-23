    StringBuilder sqlCommand = new StringBuilder();
    
    DataSet xmlDS = new DataSet();
                
    try
    {
       xmlDS.ReadXmlSchema(shemaPath); 
       xmlDS.ReadXml(dlg.FileName, XmlReadMode.ReadSchema);           
                  
       sqlCommand.Clear();
       sqlCommand.Append("START TRANSACTION;");  
                
        for (int i = xmlDS.Tables.Count-1; i >= 0; i--)
        {
           if (xmlDS.Tables[i].Rows.Count > 0) 
              sqlCommand.Append("DELETE FROM " + xmlDS.Tables[i].TableName + "; ");
        }   
    
        int brojacDataTable = 0;             
    
        foreach (DataTable dataTable in xmlDS.Tables) 
        {
            brojacDataTable++;
            if (dataTable.Rows.Count > 0)
            {    
              sqlCommand.Append(" INSERT INTO " + dataTable.TableName + " VALUES");
    
              int brojacDataRows = 0;
              foreach (DataRow dataRow in dataTable.Rows)
              {
                 brojacDataRows++;
                 sqlCommand.Append("(");
                                
                 for (int i = 0; i < dataRow.ItemArray.Length; i++)
                 {
                    if (!System.DBNull.Value.Equals(dataRow.ItemArray[i]))
                    {
                      if (dataRow.ItemArray[i] is System.DateTime) sqlCommand.Append("'" +((DateTime)dataRow.ItemArray[i]).ToString("yyyy-MM-dd") + "'");
                      else sqlCommand.Append("'" + dataRow.ItemArray[i].ToString() + "'");
                    }
                    else sqlCommand.Append("null");
    
                   if (i < dataRow.ItemArray.Length - 1) sqlCommand.Append(",");
                 }
    
                if (brojacDataRows < dataTable.Rows.Count) sqlCommand.Append("),");
                else sqlCommand.Append(");");
               }
            }
         }
    
      sqlCommand.Append("COMMIT;");
