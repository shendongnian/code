    protected void rg_ItemCommand(object sender, GridCommandEventArgs e)
        {            
            if (e.CommandName == "ExpandRow")
            {
                GridDataItem item = rg.Items[int.Parse(e.CommandArgument.ToString())];
                item.Edit = item.Edit ? false : true; // If it's already in edit mode, change it to false. If not, set it to true
                rg.Rebind();
            }
        }
