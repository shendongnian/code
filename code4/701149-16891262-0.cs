    float _total;
    protected void grdv_cart_RowDataBound(object sender, GridViewRowEventArgs e)
    {
     if (e.Row.RowType == DataControlRowType.DataRow)
     {
      DataRow dr = ((DataRowView)e.Row.DataItem).Row;
      float itemPrice = float.Parse(dr["ItemPrice"].ToString());
      _total += itemPrice;
     }
    if (e.Row.RowType == DataControlRowType.Footer)
    {
      //here write the totals into labels
    }
