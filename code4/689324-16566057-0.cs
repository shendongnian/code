    if (e.Row.RowType == DataControlRowType.DataRow)
    {
      Label lblAmt = (Label)e.Row.FindControl("lblAmt");
      decimal Profitprice = 0;
      if(Decimal.TryParse(lblAmt.Text, out Profitprice));
      {
         totProfit += Profitprice;
      }
    }
