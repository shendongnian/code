    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        HyperLink hlControl = new HyperLink();
	    hlControl.Text = e.Row.Cells[0].Text; 
	    hlControl.NavigateUrl = "page.aspx?id" + e.Row.Cells[0].Text;
	    e.Row.Cells[3].Controls.Add(hlControl);
    }
