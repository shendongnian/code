    foreach (GridViewRow row in gvMaster.Rows) 
    {
        if (row.RowType == DataControlRowType.DataRow) 
        {
            GridView gvChild = (GridView) row.FindControl("nestedGridView");
            // Then do the same method for check box column 
            if (gvChild != null)
            {
                foreach (GridViewRow row in gvChild .Rows) 
                {
                    if (row.RowType == DataControlRowType.DataRow) 
                    {
                        CheckBox chk = (CheckBox) row.FindControl("chkselect");
                        if (chk.Checked)
                        {
                            // do your work
                        }
                    }
                }
            }
        }
    }
