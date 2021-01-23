    private string docPath = "";
    protected void Page_Load(object sender, EventArgs e)
    {
         docPath = ResolveClientUrl("~/Uploads/");
    }
    protected void gv_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        HyperLink FileHyperlink = null;
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
           FileHyperlink = (HyperLink)e.Row.Cells[0].Controls[0];
           string fileName = FileHyperlink.Text.Replace("'", "''");
           FileHyperlink.NavigateUrl = docPath + fileName;
        }
    }
