    DataTable dt = new DataTable();
    foreach(DataControlFieldHeaderCell column in yourGridview.HeaderRow.Cells)
    {
      dt.Columns.Add(column.Text.Trim().Replace(" ", ""));                           
    }
