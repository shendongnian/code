    protected void rptPagination_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
    	if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
    	{
    		// Error
    		Tuple<DateTime, Boolean> datePagination = (Tuple<DateTime, Boolean>)e.Item.DataItem;
    		
    		Label lblDay = (Label)FindControl("lblDay");
    		lblDay.Text = datePagination.Item1.ToString("dd/MM/yyyy");
    		lblDay.Enabled = datePagination.Item2;
    	}
    }
