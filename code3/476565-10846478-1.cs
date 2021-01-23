    protected void btnDateUp_Click(object sender, ImageClickEventArgs e)
        {
            sortingQuery = " ORDER BY OrderDate DESC ";
            if (radioListReport.SelectedValue == "1")
                SortGrid();
            else
                SortQuarterGrid();
            updatePanelGrid.Update();
        }
    protected void btnDateDown_Click(object sender, ImageClickEventArgs e)
        {
            sortingQuery = " ORDER BY OrderDate ASC ";
            if (radioListReport.SelectedValue == "1")
                SortGrid();
            else
                SortQuarterGrid();
            updatePanelGrid.Update();
        }
