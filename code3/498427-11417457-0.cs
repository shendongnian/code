	public string[] GetExcelSheetNames(string excelFileName)
	{
            OleDbConnection con = null;
            DataTable dt = null;
            String conStr = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + excelFileName + ";Extended Properties=Excel 8.0;";
            con= new OleDbConnection(conStr);
            con.Open();
            dt = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
            if (dt == null)
            {
                return null;
            }
            String[] excelSheetNames = new String[dt.Rows.Count];
            int i = 0;
            foreach (DataRow row in dt.Rows)
            {
                excelSheetNames[i] = row["TABLE_NAME"].ToString();
                i++;
            }
            return excelSheetNames;
	}
