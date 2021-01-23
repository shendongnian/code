    const string CONNECTION_STRING = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=<FILENAME>;Extended Properties=\"Excel 8.0;HDR=no;\";";
    OleDbConnection objConnection = new OleDbConnection(CONNECTION_STRING.Replace("<FILENAME>", fullFileName));
    DataSet dsImport = new DataSet();		
    try
    {
    	objConnection.Open();
         DataTable dtSchema = objConnection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
         if( (null != dtSchema) && ( dtSchema.Rows.Count > 0 ) )
    	{
    	    string firstSheetName == dtSchema.Rows[0]["TABLE_NAME"].ToString();
             new OleDbDataAdapter("SELECT * FROM [" + firstSheetName + "]", objConnection).Fill(dsImport);
    	}
    	catch
    	{
            throw;
    	}
    	finally
    	{
    	    // Clean up.
    	    if(objConnection != null)
    	    {
    		objConnection.Close();
    	         objConnection.Dispose();
    	    }
    	}
	return (dsImport.Tables.Count > 0) ? dsImport.Tables[0] : null;
