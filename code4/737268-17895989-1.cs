    protected void GridView_RowDataBound(object sender, GridViewRowEventArgs e)
    {
      if (e.Row.RowType == DataControlRowType.DataRow)
      {
        HyperLink link = e.Row.Cells[0].Controls[0] as HyperLink;
        if (link != null)
        {
          link.NavigateUrl = link.Text; //"Link Url";
          link.Text = "Click to open this link"; // You may alter the link text.
        }
      }
    }
