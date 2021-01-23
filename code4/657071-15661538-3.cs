    protected void gridview1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            var footer = new Label();
            footer.Text = "Footer content";
            //Footer will be displayed under the *first* column
            e.Row.Cells[0].Controls.Add(footer); 
       }
    }
