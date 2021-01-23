    protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //Find the DropDownList in the Row
            
            DropDownList DropDown = (e.Row.FindControl("DropDown") as DropDownList);
            DropDown.DataSource = TheDatatable;
    		DropDown.DisplayMember = "Name";
    		DropDown.ValueMember = "ID";
    		DropDown.DataBind();
            
            DropDown.SelectedIndexChanged += new EventHandler(DDL_SelectedIndexChanged);
        }
    }
    
    protected void DDL_SelectedIndexChanged(object sender, EventArgs e)
    {
      	value = ((DropDownList)sender).SelectedValue;
    }
