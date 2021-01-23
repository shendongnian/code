    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        var Button1= e.Row.FindControl("Button1") as Button;
        Button1.CommandName = "ButtonClick";
        // cast RowIndex in line code to string if e.CommandArgument accepts string
        Button1.CommandArgument = e.Row.RowIndex;
    }
