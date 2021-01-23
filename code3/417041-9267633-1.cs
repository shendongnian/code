    protected void gridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if(e.Row.RowType == DataControlRowType.Header)
        {
            var imageButton = (ImageButton)e.Row.FindControl("Name_SortImgBtn");
            imageButton.ImageUrl = "~/myimage.gif";
        }
    }
