     protected void RadGrid2_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("Shipper", typeof(string));
        dt.Rows.Add("Shipper1");
        dt.Rows.Add("Shipper2");
        dt.Rows.Add("Shipper3");
        RadGrid2.DataSource = dt;
    }
   
    protected void RadGrid2_ItemDataBound(object sender, GridItemEventArgs e)
    {
        if (e.Item is GridDataItem)
        {
            GridDataItem item = e.Item as GridDataItem;
            TableCell tb = item["Shipper"];
            HyperLink lnk = new HyperLink();
            lnk.ID = "lnk";
            lnk.Text = (item.DataItem as DataRowView)["Shipper"].ToString();
            lnk.NavigateUrl = "https://www.google.co.in/";
            tb.Controls.Clear();
            tb.Controls.Add(lnk);
        }
    }
