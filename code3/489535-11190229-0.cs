    protected void myGridView_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        var linkButton = (LinkButton)e.Row.FindControl("EditColLocation");
        if (linkButton != null) 
        {
            if (*your condition to check*)
                linkButton.Visible = false; 
        }
    }
