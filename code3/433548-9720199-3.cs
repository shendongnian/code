    protected void GridData_RowEditing(object sender, GridViewEditIndex e)
    {
        DropDownList id = ((DropDownList)GridData.Rows[e.NewEditIndex].FindControl("DDLData"));
        if(id.SelectedValue == "Yes") 
        { 
             Column1.Visible = true;
             Column2.Visible = true; 
        }
    }
