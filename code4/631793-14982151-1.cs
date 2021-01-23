    protected void DataList1_ItemDataBound(object sender, DataListItemEventArgs e)
       {
           TextBox tbCurrentTextBox = (TextBox)e.Item.FindControl("tTextBox");
           if (DataList1.Items[e.Item.ItemIndex].AccessKey[0].ToString() == "1")
           {
               e.Item.Visible = false;
           }
       }
