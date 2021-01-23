		private void Repeater_ItemCreated(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
		{
			if(e.Item.ItemType==ListItemType.Item || e.Item.ItemType==ListItemType.AlternatingItem)
			{
			    var lb = (LinkButton)e.Item.FindControl("lb1");
                if(IsPostBack && e.Item.ItemIndex==0)
                {
                    SubmitInfo.Click+= (source,args)=>Repeater_ItemCommand(lb,new RepeaterCommandEventArgs(e.Item,lb,new CommandEventArgs(lb.CommandName,lb.CommandArgument)));
                }
    ...
