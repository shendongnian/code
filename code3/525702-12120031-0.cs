    foreach (GridViewRow row in grdSubClaimOuter.Rows) 
    {
    if (row.RowType == DataControlRowType.DataRow) 
    {
        GridView gvChild = (GridView) row.FindControl("grdSubClaim");
        // Then do the same method for Button control column 
        if (gvChild != null)
        {
            foreach (GridViewRow row in gvChild .Rows) 
            {
                if (row.RowType == DataControlRowType.DataRow) 
                {
                    Button btn = (Button ) row.FindControl("buttonID");
                    if (btn != null )
                    {
                        // do your work
                    }
                }
            }
        }
    }
    }
