    public void gridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if(e.Row.RowType != DataControlRowType.DataRow)
        {
            return;
        }
        DataRow row = (DataRow)e.Row.DataItem;
        Label lblSellingPaymentMethod = 
            e.Row.FindControl("lblSellingPaymentMethod") as Label;
    
        if(condition == true)
        {
            lblSellingPaymentMethod.Text = row["sellingpaymentmethod"].ToString();
        }
        else
        {
            lblSellingPaymentMethod.Text = row["deliverypaymentmethod"].ToString();
        }
    }
