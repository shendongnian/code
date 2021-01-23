    protected void Grid_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataRow row = ((DataRowView)e.Row.DataItem).Row;
            DropDownList ddlProducts = (DropDownList)e.Row.FindControl("ddlProductNames");
            ddlProducts.DataSource = someDataSource;
            ddlProducts.DataTextField = "name";
            ddlProducts.DataValueField = "productId";
            ddlProducts.DataBind();
        }
    }
