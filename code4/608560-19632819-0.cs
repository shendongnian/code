    protected void gridView1_RowDataBound(Object sender, GridViewRowEventArgs e)
    {
     if(e.Row.RowType == DataControlRowType.DataRow)
     {
      Image imgGridview = (Image) e.Row.FindControl("imgGrv");
      imgGridview.ImageUrl = "images/test.gif";
     }
    }
