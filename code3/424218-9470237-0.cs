    DataTable dt = new DataTable();
    dt.Columns.Add("Column1");
    dt.Columns.Add("Column2");
    
    foreach (GridViewRow row in GridView1.Rows)
    {
        dt.Rows.Add(GridView1.HeaderRow.Cells[0].Text, row.Cells[0].Text);
    }
    
    cht.DataSource = dt;
    
    cht.Series["serie"].XValueMembers = "Column1";
    cht.Series["serie"].YValueMembers = "Column2";
    
    cht.DataBind();
