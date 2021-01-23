    int firstDisplayed = liveDataTable.FirstDisplayedScrollingRowIndex;
    int displayed = liveDataTable.DisplayedRowCount(true);
    int lastVisible = (firstDisplayed + displayed) - 1;
    int lastIndex = liveDataTable.RowCount - 1;
    liveDataTable.Rows.Add(new DataGridViewRow());  //Add your row
    if(lastVisible == lastIndex)
    {
         liveDataTable.FirstDisplayedScrollingRowIndex = firstDisplayed + 1;
    }
