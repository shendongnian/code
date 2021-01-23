    public static DataSet ImportExcelXLS(string FileName, bool hasHeaders) {
    string HDR = hasHeaders ? "Yes" : "No";
    string strConn;
    if (FileName.Substring(FileName.LastIndexOf('.')).ToLower() == ".xlsx")
        strConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + FileName + ";Extended Properties=\"Excel 12.0;HDR=" + HDR + ";IMEX=0\"";
    else
        strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + FileName + ";Extended Properties=\"Excel 8.0;HDR=" + HDR + ";IMEX=0\"";
    DataSet output = new DataSet();
    using (OleDbConnection conn = new OleDbConnection(strConn)) {
        conn.Open();
        DataTable schemaTable = conn.GetOleDbSchemaTable(
            OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
        foreach (DataRow schemaRow in schemaTable.Rows) {
            string sheet = schemaRow["TABLE_NAME"].ToString();
            if (!sheet.EndsWith("_")) {
                try {
                    OleDbCommand cmd = new OleDbCommand("SELECT * FROM [" + sheet + "]", conn);
                    cmd.CommandType = CommandType.Text;
                    DataTable outputTable = new DataTable(sheet);
                    output.Tables.Add(outputTable);
                    new OleDbDataAdapter(cmd).Fill(outputTable);
                } catch (Exception ex) {
                    throw new Exception(ex.Message + string.Format("Sheet:{0}.File:F{1}", sheet, FileName), ex);
                }
            }
        }
    }
    return output;
    } 
