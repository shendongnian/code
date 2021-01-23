    protected void ED_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item)
        {
            Label title = (Label)e.Item.FindControl("title");
            title.Text = ((System.Xml.XmlElement)e.Item.DataItem).ChildNodes[0].InnerText;
    
            Label desc = (Label)e.Item.FindControl("desc");
            desc.Text = ((System.Xml.XmlElement)e.Item.DataItem).ChildNodes[1].InnerText.Substring(1, 300);
        }
    }
