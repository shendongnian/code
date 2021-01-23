    public int sum = 0;
    protected void GirdView2_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {   
            //Sum the value of each subtotal
            sum = sum + subTotalValue;
            //Access the control that you want to to set the GrandTotal in
        }
    }
