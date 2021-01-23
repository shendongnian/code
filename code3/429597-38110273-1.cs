    DataTable dt = new DataTable();
    foreach(DataControlFieldHeaderCell column in yourGridview.HeaderRow.Cells)
    {
      dt.Columns.Add(column.Text.Trim().Replace(" ", ""));                           
    }
    //Make sure you do all this after yourGridview.DataBind(); 
    //If you do not want to bind data first simply bind an empty list like so:
    /* yourGridview.DataSource = new List<string>();
       yourGridview.DataBind(); */
