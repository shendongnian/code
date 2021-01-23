    protected void rpt_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Label lbl = (Label)e.Item.FindControl("lblDescription");
            lbl.Text = ((Order)e.Item.DataItem).FeeType.Desc;
    
            Label lblAmount = (Label)e.Item.FindControl("lblAmount");
            lblAmount.Text = ((Order)e.Item.DataItem).Amount.ToString();
        }
    }
