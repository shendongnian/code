    protected void gridview1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            TextBox txtqty = (TextBox)e.Row.FindControl("txtqty");
            txtqty.Attributes.Add("onchange", "return confirmUpdate(this, 'Are you sure you want to continue')");
        }
    }
