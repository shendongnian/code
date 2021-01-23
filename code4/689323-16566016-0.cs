    decimal totProfit = 0M;
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblAmt = (Label)e.Row.FindControl("lblAmt");
            decimal Profitprice; 
            if (Decimal.TryParse(lblAmt.Text, Profitprice) ) {
                 totProfit += Profitprice;
            }
        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            Label lblTotalAmt = (Label)e.Row.FindControl("lblTotalAmt");
            lblTotalAmt.Text = totProfit.ToString();
        }
    }     
