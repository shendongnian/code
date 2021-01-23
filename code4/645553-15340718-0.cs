    protected void ResultsGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        // var gridResult = Session["ResultQuery"].ToString();
        var gridResult = (Product)Session["ResultQuery"];
        ResultsGridView.PageIndex = e.NewPageIndex;
        ResultsGridView.DataSource = gridResult;
        ResultsGridView.DataBind();
    }
