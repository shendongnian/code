    int _selectedRow = -1;
    int _selectedColumn = -1;
    private void dataGridView1_SelectionChanged(object sender, EventArgs e)
    {
        switch (dataGridView1.SelectedCells.Count)
        {
            case 0:
                // store no current selection
                _selectedRow = -1;
                _selectedColumn = -1;
                return;
            case 1:
                // store starting point for multi-select
                _selectedRow = dataGridView1.SelectedCells[0].RowIndex;
                _selectedColumn = dataGridView1.SelectedCells[0].ColumnIndex;
                return;
        }
        foreach (DataGridViewCell cell in dataGridView1.SelectedCells)
        {
            if (cell.RowIndex == _selectedRow)
            {
                if (cell.ColumnIndex != _selectedColumn)
                {
                    _selectedColumn = -1;
                }
            }
            else if (cell.ColumnIndex == _selectedColumn)
            {
                if (cell.RowIndex != _selectedRow)
                {
                    _selectedRow = -1;
                }
            }
            // otherwise the cell selection is illegal - de-select
            else cell.Selected = false;
        }
    }
