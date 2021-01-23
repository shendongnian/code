	protected void questionsGridView_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
	{
		DataSourceDataType row;
		HyperLink hyperLink1;
		if (e.Row.RowType == DataControlRowType.DataRow & e.Row.DataItem is DataSourceDataType)
		{
			row = (DataSourceDataType)e.Row.DataItem;
			hyperLink1 = (HyperLink)e.Row.FindControl("HyperLink1");
			hyperLink1.ImageUrl = (row.IsSuccess) ? "~/images/success.png" : "~/images/failure.png";
		}
	}
