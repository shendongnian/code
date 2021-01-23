    private void ObjectListView1OnCellEditStarting(object sender, CellEditEventArgs e) {
        // special cell edit handling for our delete-row
        if (e.Column == deleteColumn) {
            e.Cancel = true;		// we don't want to edit anything
            objectListView1.RemoveObject(e.RowObject); // remove object
        }
    }
