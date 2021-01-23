    protected void gvBill_RowDataBound(object sender, GridViewRowEventArgs e)
        {
    
            if (e.Row.RowType == DataControlRowType.DataRow)
    
                Total += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "InvMstAmount"));
            else if (e.Row.RowType == DataControlRowType.Footer)
    
                e.Row.Cells[7].Text = String.Format("{0:0}", "<b>" + Total + "</b>");
        }
