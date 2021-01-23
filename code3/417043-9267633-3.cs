    protected void gridView1_RowDataBound(object sender, GridViewRowEventArgs e) 
    {
        if (e.Row.RowType == DataControlRowType.Header) 
        {
            //Determine sort column and sort order
            var column = ViewState["SortExpression"] != null ? 
                         ViewState["SortExpression"].ToString() : string.Empty;
            var sortDirection = ViewState["SortDirection"] != null ? 
                         ViewState["SortDirection"].ToString() : string.Empty;
            //Find ImageButton based on sort column (return if not found)
            var imageButtonID = string.Concat(column, "_SortImgBtn");
            var imageButton = e.Row.FindControl(imageButtonID) as ImageButton;
            if(imageButton == null) return;
            //Determine sort image to display
            imageButton.ImageUrl = string.Equals("asc", sortDirection.ToLower()) ?
                                   "~/App_Themes/Sugar2006/Images/arrow_up.gif" :
                                   "~/App_Themes/Sugar2006/Images/arrow_down.gif";
            imageButton.Visible = true;
        }
    }
