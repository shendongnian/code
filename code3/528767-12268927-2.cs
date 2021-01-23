    protected void accReviewers_ItemCommand(object sender, CommandEventArgs e)
    {
    	//This seems stupid to put here, but for some reason the item command bypasses the listview catch and passes it to the accordion
    	
    	if (e.CommandName == "ApproveReview")
    	{
    		var assigneeGuid = new Guid(e.CommandArgument.ToString().Split('|')[0]);
    		var ticketId = int.Parse(e.CommandArgument.ToString().Split('|')[1]);
    		var ticket = new MocApproval(ticketId);
    		DoDemoApproval(ticketId, assigneeGuid, true);
    		var approvalIndex = (sender as AjaxControlToolkit.Accordion).SelectedIndex;
    		var lv =
    			(sender as AjaxControlToolkit.Accordion).Panes[approvalIndex].FindControl("lvReviewers") as ListView;
    		lv.DataSource = MocApi.GetReviews(ticket.MocRequest);
    		lv.DataBind();
    		return;
    	}
    	if (e.CommandName == "DenyReview")
    	{
    		var assigneeGuid = new Guid(e.CommandArgument.ToString().Split('|')[0]);
    		var ticketId = int.Parse(e.CommandArgument.ToString().Split('|')[1]);
    		var ticket = new MocApproval(ticketId);
    		DoDemoApproval(ticketId, assigneeGuid, false);
    		var approvalIndex = (sender as AjaxControlToolkit.Accordion).SelectedIndex;
    		var lv =
    			(sender as AjaxControlToolkit.Accordion).Panes[approvalIndex].FindControl("lvReviewers") as ListView;
    		lv.DataSource = MocApi.GetReviews(ticket.MocRequest);
    		lv.DataBind();
    		return;
    	}
    	
    	...
