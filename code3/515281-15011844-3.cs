    private void myDataGrid_OnCellMouseUp(object sender,DataGridViewCellMouseEventArgs e)
    {
        // End of edition on each click on column of checkbox
        if (e.ColumnIndex == myCheckBoxColumn.Index && e.RowIndex != -1)
        {
            myDataGrid.EndEdit();
        }
    }
