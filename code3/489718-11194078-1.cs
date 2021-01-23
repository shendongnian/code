	protected void reportedIssuesGridView_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
	{
		RowDataType row;
		HyperLink viewHyperLink = default(HyperLink);
		if (e.Row.RowType == DataControlRowType.DataRow && e.Row.DataItem is RowDataType) {
			row = (RowDataType)e.Row.DataItem;
			viewHyperLink = (HyperLink)e.Row.FindControl("viewHyperLink");	//Gets the HyperLink
			viewHyperLink.NavigateUrl = "~/Edit/Default.aspx?P_ID" + row.Id;
			viewHyperLink.Visible = (row.Id != "ABC");
			
		}
	}
