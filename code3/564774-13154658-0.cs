    protected void GridView_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //use this way
            e.Row.ToolTip = "My FooBar tooltip";
             //or use this way
            e.Row.Attributes.Add("title", "My FooBar tooltip");
        }
     }
