    dataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
    dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
    dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
    // ... Bind the data here ...
    // Set the DataGridView auto-size modes back to their original settings.
    dataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
    dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
    dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
