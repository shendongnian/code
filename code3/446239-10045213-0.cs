    public void UpdateDescription(DataTable dataTable) {
      if ((dataTable != null) && (0 < dataTable.Rows.Count)) {
        int rowIndex = 0;
        //DataRow dr = journalTable.Rows[0]; // What was this line for? "journalTable" is not defined here.
        if (rowIndex < dataTable.Rows.Count) {
          DataRow dr = dataTable.Rows[rowIndex];
          if (!dr.IsNull("DataDesc")) {
            string dataDesc = dr["DataDesc"].ToString();
            if (dataDesc.Contains("STATE")) {
              dataDesc = dataDesc.Replace("STATE", "").Trim();
            }
            if (dataDesc.Contains("HELLO ALL")) {
              dataDesc = dataDesc.Replace("HELLO ALL", "").Trim();
            }
            if (dataDesc.Contains("(")) {
              dataDesc = dataDesc.Remove(dataDesc.IndexOf("(")).Trim();
            }
            dr["DataDesc"] = dataDesc;
          }
        }
        rowIndex++;
      }
    }
