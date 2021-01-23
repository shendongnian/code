    protected void Gridview_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
       update();
 
    }
    private void update()
    {
     DataTable dt = new DataTable();
     dt.Columns.Add("ab", typeof(string));
     dt.Columns.Add("ac", typeof(string));
     dt.Columns.Add("av", typeof(string));
     dt.Columns.Add("ax", typeof(string));
     DataRow row = dt.NewRow();
     row["ac"] = "newvalue";
     row["av"] = "newvalue";
     row["av"] = "newvalue";
     row["ax"] = "newvalue";
     dt.Rows.Add(row);
     GridView1.DataSource = dt;
     GridView1.DataBind();
     }
