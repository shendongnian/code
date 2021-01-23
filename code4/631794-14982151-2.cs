    protected void DataList1_ItemDataBound(object sender, DataListItemEventArgs e)
       {
           if (e.Item.ItemType == ListItemType.Item)
           {
               TextBox tbCurrentTextBox = (TextBox)e.Item.FindControl("tTextBox");
               if (DataList1.Items[e.Item.ItemIndex].ToString() == "1")
               {
                   e.Item.Visible = false;
               }
           }
       }
