    protected void GridView_RowDataBound(object sender, GridViewRowEventArgs e)
    {
      if (e.Row.RowType == DataControlRowType.DataRow)
      {
        HyperLink link = e.Row.Cells[0].Controls[0] as HyperLink;
        if (link != null)
        {
          link.Text = "Link Text";
          link.NavigateUrl = "Link Url";
        }
      }
    }
