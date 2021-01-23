    protected void button_OnClick(object sender, EventArgs e)
    {
    	foreach (RepeaterItem item in rptDummy.Items)
    	{
    		RadioButtonList list = (RadioButtonList)item.FindControl("rbl");
    		string selectedValue = list.SelectedValue;
    	}
    }
