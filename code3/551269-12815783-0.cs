    /// <summary>
    /// This method retrieves the excel sheet names from 
    /// an excel workbook.
    /// </summary>
    /// <param name="excelFile">The excel file.</param>
    /// <returns>String[]</returns>
    private String[] GetExcelSheetNames(string excelFile)
    {
        OleDbConnection objConn = null;
        System.Data.DataTable dt = null;
        try
        {
            // Connection String. Change the excel file to the file you
            // will search.
            String connString = "Provider=Microsoft.Jet.OLEDB.4.0;" + 
              "Data Source=" + excelFile + ";Extended Properties=Excel 8.0;";
            // Create connection object by using the preceding connection string.
            objConn = new OleDbConnection(connString);
            // Open connection with the database.
            objConn.Open();
            // Get the data table containg the schema guid.
            dt = objConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
 
            if(dt == null)
            {
               return null;
            }
            String[] excelSheets = new String[dt.Rows.Count];
            int i = 0;
            // Add the sheet name to the string array.
            foreach(DataRow row in dt.Rows)
            {
               excelSheets[i] = row["TABLE_NAME"].ToString();
               i++;
            }
            // Loop through all of the sheets if you want too...
            for(int j=0; j < excelSheets.Length; j++)
            {
                // Query each excel sheet.
            }
            return excelSheets;
       }
       catch(Exception ex)
       {
           return null;
       }
       finally
       {
          // Clean up.
          if(objConn != null)
          {
              objConn.Close();
              objConn.Dispose();
          }
          if(dt != null)
          {
              dt.Dispose();
          }
       }
    }
