    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        DataRowView drv = (DataRowView)e.Row.DataItem;
        if (drv != null)
        {
            string cellValue = Convert.ToString(drv["EmpID"]);// By column name
        }
    }
