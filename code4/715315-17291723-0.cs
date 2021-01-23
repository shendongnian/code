    protected void Button1_Click(object sender, EventArgs e)
    {
        using (DataTable dt1 = getDataTable1())
        {
            using (DataSet ds1 = new DataSet())
            {
                ds1.Tables.Add(dt1);
                YourDataGridView.DataSourceID = null;
                YourDataGridView.DataSource = ds1.Tables[0].DefaultView;
                YourDataGridView.DataBind();
            }
        }
    }
