          protected void Gridview1_RowDataBound(object sender, GridViewRowEventArgs e)
    {       
        try
        {
            HyperLink hlControl = new HyperLink();
            hlControl.Text = "Info";
            hlControl.NavigateUrl = e.Row.Cells[3].Text;
            e.Row.Cells[3].Controls.Add(hlControl);
        }
        catch
        {
        }
    }
