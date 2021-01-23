	protected void reportedIssuesGridView_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
	{
		RowDataType row;
		HyperLink viewHyperLink;
		Label messageLabel;
		if (e.Row.RowType == DataControlRowType.DataRow && e.Row.DataItem is RowDataType) {
			row = (RowDataType)e.Row.DataItem;
			viewHyperLink = (HyperLink)e.Row.FindControl("viewHyperLink");	//Gets the HyperLink
			messageLabel = (Label)e.Row.FindControl("messageLabel");	//Gets the Label
			if (row.Id != "ABC")
			{
				viewHyperLink.Visible = true;
				viewHyperLink.NavigateUrl = "~/Edit/Default.aspx?P_ID" + row.Id;
				messageLabel.Visible = false;
				
			}
			else
			{
				viewHyperLink.Visible = true;
				messageLabel.Visible = true;
				messageLabel.Text = row.Id;
			}
		}
	}
