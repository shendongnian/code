    public void gvDataBound(object sender, GridViewRowEventArgs e)
    {
        if(e.Row.RowType != DataControlRowType.DataRow)
        {
            return;
        }
        var item = (string[]) e.Row.DataItem;
        Label myLabel = e.Row.FindControl("myLabel") as Label;
        myLabel.Text = item[0];
    }
