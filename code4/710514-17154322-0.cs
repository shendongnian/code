    //EditingControlShowing event handler for your DataGridView
    private void dataGridView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
    {
            DataGridViewTextBoxEditingControl cellEdit = e.Control as DataGridViewTextBoxEditingControl;
            cellEdit.AutoCompleteCustomSource = new AutoCompleteStringCollection();
            cellEdit.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cellEdit.AutoCompleteSource = AutoCompleteSource.CustomSource;
            int colIndex = dataGridView.CurrentCell.ColumnIndex;
            if (colIndex == 8) cellEdit.AutoCompleteCustomSource.AddRange(new string[] { "Aaaa", "Bbbb", "Cccc" });
            else if (colIndex == 9) cellEdit.AutoCompleteCustomSource.AddRange(new string[] { "1234", "5678" });            
    }
