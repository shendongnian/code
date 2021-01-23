    protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            DataRowView row = (DataRowView) e.Item.DataItem;
            Button btn = (Button) e.Item.FindControl("ButtonID");
            object productID = row["productID"];
            object eventnumber = row["eventnumber"];
            object type = row["type"];
            if(DBNull.Value == eventnumber || string.IsNullOrWhiteSpace(eventnumber.ToString()))
            {
                btn.Text = string.Format("{0}|{1}", productID, type);
            }
            else
            {
                btn.Text = string.Format("{0}", eventnumber);
            }
        }
    }
