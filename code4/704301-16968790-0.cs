	protected void ddlFacility2_OnSelectedIndexChanged(object sender, EventArgs e)
	{
		if(ddlFacility2.SelectedIndex>-1)
		{
			btnCreate.Enabled = true;
		}
                		else
		{
			btnCreate.Enabled = false;
		}
	}
 
