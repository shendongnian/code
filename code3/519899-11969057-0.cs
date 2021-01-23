    public void Data_table()
    {
        Session["Data"] = "";
        DataTable dt = new DataTable();
        //Add Columns to the datatable
        dt.Columns.Add("c1");
        dt.Columns.Add("c2");
        dt.Columns.Add("c3");
        //Define a datarow for the datatable dt
        DataRow dr = dt.NewRow();
        //Now add the datarow to the datatable
        Session["Data"] = dt;
        RadGrid1.DataSource = dt;
        RadGrid1.Rebind();
    }
    protected void RadGrid1_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    {            
        if (((System.Data.DataTable)(Session["Data"])).Rows.Count.ToString() != "")
        {
            RadGrid1.DataSource = Session["Data"];
        }
    }
