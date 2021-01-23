    protected void rptActivity_ItemCreated(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item){
            var helper = (UpdateActivitiesHelper)e.Item.DataItem;
            DropDownList ddl = (DropDownList)e.Item.FindControl("ddlStatuses");
            ddl.SelectedValue = helper.StatusId.ToString();
        }
    }
