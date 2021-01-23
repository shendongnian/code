    protected void GridView2_RowDataBound(Object sender, GridViewRowEventArgs e)
    {
        if(e.Row.RowType == DataControlRowType.DataRow)
        {
             var priceLabel =  e.Row.FindControl("lblPrice") as Label;
             var quantityTextBox =  e.Row.FindControl("txtQuantity") as TextBox;
             var totalLabel =  e.Row.FindControl("lblPrice") as Label;
             var onKeyUpScript = String.Format(
                                      "javascript:CalculateRowTotal('#{0}', '#{1}', '#{2}');",
                                      "this.id",
                                      priceLabel.ClientID,
                                      totalLabel.ClientID);
             quantityTextBox.Attributes.Add("onkeyup", onKeyUpScript);
        }
    }
