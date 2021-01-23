    protected void myGrid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Customer cust = e.Row.DataItem as Customer;
                if (!cust.ShowURL)
                {
                    LinkButton lnkWebURL = e.Row.FindControl("lnk") as LinkButton;
                    //Set lnkWebURL stugg
                }
            }
        }
  
