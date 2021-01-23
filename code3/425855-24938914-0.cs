    protected void rptProjects_ItemCreated(object sender, RepeaterItemEventArgs e)
    {
         if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
         {
               ((DropDownList)e.Item.FindControl("yourcontrol")).SelectedIndexChanged += ddlAction_SelectedIndexChanged;
         }
    }
