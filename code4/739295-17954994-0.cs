    <asp:ListView ID="ListView1" runat="server" 
         OnItemDataBound="ListView1_ItemDataBound" ...>
      ....
    </asp:ListView>
    
    protected void ListView1_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        if (e.Item.ItemType == ListViewItemType.DataItem)
        {
            var ddlTags = e.Item.FindControl("ddlTags") as DropDownList;
            var tagsLabel = e.Item.FindControl("TagsLabel") as Label;
        }
    }
