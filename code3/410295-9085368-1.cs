    loConectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + pFullFilePath +
                          ";Extended Properties=\"Excel 12.0;HDR=No;IMEX=2\"";
    fillSourceFromExcel(loConectionString);
    private DataTable _loDtArchivoOrigen = null;
    private void fillSourceFromExcel(string pConectionString)
    {
        try
        {
            var loColumnasSelect = new StringBuilder();
            using (OleDbConnection oleDbConnection = new OleDbConnection(pConectionString))
            {
                if (oleDbConnection.State == ConnectionState.Closed) oleDbConnection.Open();
                DataTable dbSchema = oleDbConnection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables_Info, null);
                DataTable dbColumns = oleDbConnection.GetOleDbSchemaTable(OleDbSchemaGuid.Columns, new object[] { null, null, dbSchema.Rows[0]["TABLE_NAME"], null });
                foreach (DataRow loRow in dbColumns.Rows)
                {
                    loColumnasSelect.Append(" " + loRow["COLUMN_NAME"].ToString() + " as " + loRow["COLUMN_NAME"].ToString().Replace("F", "a") + ",");
                }
                using (OleDbCommand oleDbCommand = new OleDbCommand())
                {
                    oleDbCommand.Connection = oleDbConnection;
                    oleDbCommand.CommandText =
                        string.Format(
                            "SELECT " + loColumnasSelect.Remove(loColumnasSelect.Length - 1, 1) +
                            " FROM [{0}]", dbSchema.Rows[0]["TABLE_NAME"].ToString());
                    using (OleDbDataAdapter oleDbDataAdapter = new OleDbDataAdapter())
                    {
                        oleDbDataAdapter.SelectCommand = oleDbCommand;
                        oleDbDataAdapter.Fill(_loDtArchivoOrigen);
                    }
                }
                oleDbConnection.Close();
            }
        }
        catch (Exception loException)
        {
            throw;
        }
    }
