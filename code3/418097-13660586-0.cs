            protected void ItemsGrid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // Get the row variable values
                var rowView = (DataRowView)e.Row.DataItem;
                var itemId = Convert.ToInt32(rowView["ItemID"]);
                var skuId = Convert.ToInt32(rowView["ItemSkuID"]);
                var quantity = Convert.ToInt32(rowView["Quantity"]);
                // Instantiate instances of the relevant classes
                var item = new Item(itemId);
                var sku = new Sku(skuId);
                var itemPrice = String.Format("{0:n2}", (item.Price + sku.PriceAdj));
                var itemPriceLiteral = (Literal)e.Row.FindControl("ItemPrice");
                if (itemPriceLiteral != null)
                {
                    itemPriceLiteral.Text = itemPrice;
                }
                var itemExtendedPriceLiteral = (Literal)e.Row.FindControl("ItemExtendedPrice");
                if (itemExtendedPriceLiteral != null)
                {
                    var extendedPrice = price * quantity;
                    itemExtendedPriceLiteral.Text = String.Format("{0:n2}", extendedPrice);
                    // Increment the extended price
                    _totalExtendedPrice += extendedPrice;
                }
            }
        } 
