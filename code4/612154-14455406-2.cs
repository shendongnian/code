    protected void CheckBoxList1_SelectedIndexChanged(object sender, EventArgs e)
    {
    	int i=0;            
    	foreach (ListItem li in CheckBoxList1.Items)
    	{
    		if (li.Selected)
    			i++;
    	}
    	Response.Write(i);           
    }
