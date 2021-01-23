     protected void lvStock_ItemDataBound(object sender, ListViewItemEventArgs e)
     {
           if (e.Item.ItemType == ListViewItemType.DataItem) 
           {
               // Get the Product Id (or whatever ID it is)
               ListView listView = sender as ListView;
               int index = e.Item.DataItemIndex;
               DataKey dataKey = listView.DataKeys[index];
               int productId = Convert.ToInt32(dataKey["ProductId"]);
               // Get the stock value from your DB or wherever you get it from
               int stock = GetStockById(productId);
               
 
               if (stock > 10)
                   stock = 10;
               // Get the stock drop down list
               DropDownList ddlListStock = (DropDownList )e.Item.FindControl("DropDownList1");
               // add the values to the drop down list
               for (int i = 0; i <= stock; i++)
               {
                    ddlListStock.Items.Add(i.ToString());
               }
           }
      }
    
