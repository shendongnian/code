    protected void ListEvent_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
               ListViewDataItem dataItem = (ListViewDataItem) e.Item;
               Label LabelBody = (Label)e.Item.FindControl("LabelBody");
               LabelBody.Text = (string) DataBinder.Eval(dataItem.DataItem, "Body");
            }
        }
