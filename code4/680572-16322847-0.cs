    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
    
    	CheckBox c = e.Row.FindControl("ChkStatus") as CheckBox;
    	TextBox TB = e.Row.FindControl("Status") as TextBox;
    	if (c!= null && TB != null )
    	{
    		c.Checked = (TB.Text == "T");
    	}
    
    }
