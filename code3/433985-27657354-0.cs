    protected void PageDropDownList_SelectedIndexChanged(Object sender, EventArgs e)
    {
         // Retrieve the pager row.
        GridViewRow pagerRow = SubmitAppraisalGrid.BottomPagerRow;
        // Retrieve the PageDropDownList DropDownList from the bottom pager row.
        DropDownList pageList = (DropDownList)pagerRow.Cells[0].FindControl("PageDropDownList");
        // Set the PageIndex property to display that page selected by the user.
        GridViewPageEventArgs evt = new GridViewPageEventArgs(pageList.SelectedIndex);
        SubmitAppraisalGrid_PageIndexChanging(sender, evt);
    }
