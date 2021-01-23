    protected override void Render(HtmlTextWriter writer)
    {
        TextBox pageCount = new TextBox();
        pageCount = (TextBox)RtDialysisSummary.FindControl("txtPageCount");
    
        pageCount.Text = Convert.ToString(ReportViewer1.TotalPages);
        base.Render(writer);
    }
