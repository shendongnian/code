    protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row = (GridViewRow)((DropDownList)sender).Parent.Parent;
        DropDownList ddlSubCategory = (DropDownList)row.FindControl("ddlSubCategory");
        ddlSubCategory.DataSource = //whatever you want to bind, e.g. based on the selected value, using((DropDownList)sender).SelectedValue;
        ddlSubCategory.DataBind();
    }
