    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            var item = (MyType)e.Row.DataItem;
            if (item != null)
            {
                ImageButton button = (ImageButton)e.Row.FindControl("MyButton");
                if (item.Children.Count == 0)
                    button.Visible = false;
            }
        }
    }
