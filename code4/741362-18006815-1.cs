    protected void parentRep_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
       if (args.Item.ItemType == ListItemType.Item || args.Item.ItemType == ListItemType.AlternatingItem)
       {
            Repeater childRepeater = (Repeater)e.Item.FindControl("childRep");
            childRepeater.ItemDataBound += new RepeaterItemEventHandler(childRepeater_ItemDataBound);
            childRepeater.ItemCommand += new RepeaterCommandEventHandler(childRepeater_ItemCommand);
            childRepeater.DataSource = dt3; //dt3 is the DataTable from your code sample
            childRepeater.DataBind();
       }
    }
