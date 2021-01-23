        private String[] GetExcelSheetNames(string excelFile)
        {
            try
            {
                excelConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + ""yoursourcepath"+ ";Extended Properties=Excel 12.0;Persist Security Info=False";
                excelConnection = new OleDbConnection(excelConnectionString);
                excelConnection.Open();
                dt = excelConnection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                if (dt == null)
                {
                    return null;
                }
                excelSheets = new String[dt.Rows.Count];
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
                if (excelConnection != null)
                {
                    excelConnection.Close();
                    excelConnection.Dispose();
                }
                if (dt != null)
                {
                    dt.Dispose();
                }
            }
        }
