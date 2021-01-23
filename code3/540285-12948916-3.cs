       private String[] GetExcelSheetNames(string excelFile)
       {
             OleDbConnection objConn = null;
             System.Data.DataTable dt = null;
          try
          {
             String connString = "Provider=Microsoft.Jet.OLEDB.4.0;" +
               "Data Source=" + excelFile + ";Extended Properties=Excel 8.0;";
             objConn = new OleDbConnection(connString);
             objConn.Open();
             dt = objConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
             if (dt == null)
             {
                  return null;
             }
           String[] excelSheets = new String[dt.Rows.Count];
           int i = 0;
          foreach (DataRow row in dt.Rows)
          {
                excelSheets[i] = row["TABLE_NAME"].ToString();
                 i++;
          }
          return excelSheets;
        }
         catch (Exception ex)
         {
             return null;
         }
         finally
         {
              if (objConn != null)
              {
                objConn.Close();
                objConn.Dispose();
           }
            if (dt != null)
            {
                dt.Dispose();
            }
          }
        }
