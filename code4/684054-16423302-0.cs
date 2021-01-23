    private void FormView1_DataBound(object sender, System.EventArgs e)
    {
        switch (FormView1.CurrentMode)
        {
            case FormViewMode.ReadOnly:
                break;
            case FormViewMode.Edit:
                // note that the DataSource might be a different type
                DataRowView drv = (DataRowView)FormView1.DataSource;
                DropDownList StatusDropdown = (DropDownList)FormView1.FindControl("StatusDropdown");
                // you can also add the ListItems programmatcially via Items.Add
                StatusDropdown.DataSource = getAllStatus(); // a sample method that returns the datasource
                StatusDropdown.DataTextField = "Status";
                StatusDropdown.DataValueField = "StatusID";
                StatusDropdown.DataBind();
                StatusDropdown.SelectedValue = drv["StatusID"].ToString();
                break;
            case FormViewMode.Insert:
                break;
        }
    }
