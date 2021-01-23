    protected void Page_Load(object sender, EventArgs e)
    {
        gvData.RowDataBound += gvData_RowDataBound;
        gvData.DataSource = CreateData();
        gvData.DataBind();
    }
    
    void gvData_RowDataBound(object sender, GridViewRowEventArgs args)
    {
        if (args.Row.RowType == DataControlRowType.DataRow)
        {
            Literal litSum = (Literal)args.Row.FindControl("litSum");
            DataRow data = ((DataRowView)args.Row.DataItem).Row;
    
            int sum = 0;
            for (int i = 1; i < data.ItemArray.Length; i++)
            {
                sum += Convert.ToInt32(data.ItemArray[i]);
            }
    
            litSum.Text = sum.ToString();
        }
    }
    
    protected static DataTable CreateData()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("EventType", typeof(string));
        dt.Columns.Add("JAN-01", typeof(int));
        dt.Columns.Add("FEB-01", typeof(int));
        dt.Columns.Add("MAR-01", typeof(int));
    
    
        dt.Rows.Add("Item 1", 21, 100, 0);
        dt.Rows.Add("Item 2", 5, 1, 67);            
    
        return dt;
    }
