    protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
    	if (!((DataRowView)e.Item.DataItem).Row["DataType"].ToString().Trim().Equals("bool"))
    	{
    		CheckBox chkSelect = (CheckBox)e.Item.FindControl("chkSelect");
    		chkSelect.Visible = false;
    	}
    }
