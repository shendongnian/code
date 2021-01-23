    //Get the row that is selected
    DataGridViewRow dr = selectedRows.Cast<DataGridViewRow>().FirstOrDefault();
    //Your temp DataTable
    DataTable dtTemp = new DataTable();
    //If there is a row selected
    if (dr != null)
    {
      var rowToRemove = dtTemp.Rows.Cast<DataRow>().FirstOrDefault(row => row[0] == dr.Cells[0].Value);
      if (rowToRemove != null)
        dtTemp.Rows.Remove(rowToRemove);
    }
