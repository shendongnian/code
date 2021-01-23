    void GrdVw_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if(e.Row.RowType == DataControlRowType.DataRow)
        {
            Image rowImage = (Image) e.Row.FindControl("currentDocFile");
            rowImage.ImageUrl = whatever;
        }
    }
