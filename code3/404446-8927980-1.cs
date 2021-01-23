    DataTable xlsData = new DataTable();
    List<string> result = new List<string>();
    string query = string.Format("SELECT * FROM [{0}]", this.SheetName);
    OleDbDataAdapter dbAdapter = new OleDbDataAdapter(query, dbConnection);
    dbAdapter.Fill(xlsData);
    foreach (DataColumn column in xlsData.Columns)
    {
      result.Add(column.ColumnName);
    }
