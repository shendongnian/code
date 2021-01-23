    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
     
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            HyperLink hlink = (HyperLink)e.Row.FindControl("HL");
            string url = "~/Docs/" + e.Row.Cells[1].Text;
            hlink.NavigateUrl = url;
            hlink.Text = "Read";
        }
    }
