    protected void ddlContainerType_DataBound(object sender, EventArgs e)
    {
        var ddlContainerType = (DropDownList)sender;
        ddlContainerType.Items.Insert(0, new ListItem("Make a Selection", String.Empty));
        ddlContainerType.SelectedIndex = 0;
        GridViewRow gvr = (GridViewRow)ddlContainerType.NamingContainer;
        if (gvr.DataItem != null)
        {
            string strModel = ((System.Data.DataRowView)gvr.DataItem)["ContainerType"].ToString();
            ddlContainerType.ClearSelection();
            
            var li = ddlContainerType.Items.FindByValue(strModel);
            if (li != null)
                li.Selected = true;
        }
    }
