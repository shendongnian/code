    protected void begv_OrderDetail_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (row.RowType == DataControlRowType.DataRow
           && e.Row.RowIndex == begv_OrderDetail.EditIndex)
        {
            TextBox txt_Quantity = (TextBox)e.Row.FindControl("txt_Quantity");
            txt_Quantity.Attributes.Add("onFocus", "test(this)");
        }
    }
    
   
