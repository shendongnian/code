    protected void OnSelectedIndexChanging(object sender, EventArgs e)
    {
        DropDownList id = (DropDownList)sender;
        GridViewRow row = GridData.Rows[GridData.EditIndex];
        if(id.SelectedValue == "Yes")
        {
            TextBox column1 = (TextBox)row.FindControl("Column1ID");
            column1.Visible = true;
            TextBox column2 = (TextBox)row.FindControl("Column2ID");
            column2.Visible = true;
        }
    }
