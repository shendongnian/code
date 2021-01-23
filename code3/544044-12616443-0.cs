        protected void Load() {
                DataSet ds = new DataSet();
    if(ds.Tables.Count == 0)
    {
     // Syntax might be wrong. I am trying to add new table if it is missing.
      ds.Table.Add(new Table());
    }
                ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                GridView1.DataSource = ds;
                GridView1.DataBind();
                int columncount = GridView1.Rows[0].Cells.Count;
                GridView1.Rows[0].Cells.Clear();
                GridView1.Rows[0].Cells.Add(new TableCell());
                GridView1.Rows[0].Cells[0].ColumnSpan = columncount;
                GridView1.Rows[0].Cells[0].Text = "No records on display";
            }
