    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
       if (e.Row.RowType == DataControlRowType.DataRow)
       {
          Label lblPrice = (Label)e.Row.FindControl("lblPrice");
          Label lblUnitsInStock = (Label)e.Row.FindControl("lblUnitsInStock");
    
          decimal price = Decimal.Parse(lblPrice.Text);
          decimal stock = Decimal.Parse(lblUnitsInStock.Text);
    
          totalPrice += price;
          totalStock += stock;
    
          totalItems += 1;
       }
    
       if (e.Row.RowType == DataControlRowType.Footer)
       {
          Label lblTotalPrice = (Label)e.Row.FindControl("lblTotalPrice");
          Label lblTotalUnitsInStock = (Label)e.Row.FindControl("lblTotalUnitsInStock");
    
          lblTotalPrice.Text = totalPrice.ToString();
          lblTotalUnitsInStock.Text = totalStock.ToString();
    
          lblAveragePrice.Text = (totalPrice / totalItems).ToString("F");
       }
    }
