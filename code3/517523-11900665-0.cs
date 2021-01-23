    OleDbConnection objConn = null;
    System.Data.DataTable dt = null;
    string excelConnection = "";
      
    if(strFile.Trim().EndsWith(".xlsx"))
    {
        excelConnection = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=\"Excel 12.0 Xml;HDR=YES;IMEX=1\";", strFile);
    }
    else if(strFile.Trim().EndsWith(".xls")) 
    {
        excelConnection = string.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=1\";", strFile);
    }
    
    objConn = new OleDbConnection(excelConnection);
    
    objConn.Open();
    
    dt = objConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
    
    String[] excelSheets = new String[dt.Rows.Count];
    int i = 0;
    
    foreach(DataRow row in dt.Rows)
    {
        excelSheets[i] = row["TABLE_NAME"].ToString();
        i++;
    }
    
    for(int j=0; j < excelSheets.Length; j++)
    {
        OleDbCommand cmd = new OleDbCommand("Select * from " + excelSheets[j], excelConnection);
    
        excelConnection.Open();
        OleDbDataReader dReader;
        dReader = cmd.ExecuteReader();
        SqlBulkCopy sqlBulk = new SqlBulkCopy(strConnection);
    
        sqlBulk.DestinationTableName = "YourDestinationTableName";
    
        sqlBulk.WriteToServer(dReader);
        excelConnection.Close();
    }
