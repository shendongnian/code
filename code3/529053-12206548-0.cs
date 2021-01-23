    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
        if (msg.Msg == 256) // WM_KEYDOWN
        {
            if (this.ActiveControl == dataGridViewPlatypus)
            {
                var currentCell = dataGridViewPlatypus.CurrentCell;
                if (currentCell.OwningColumn is DataGridViewTextBoxColumn && currentCell.Value.ToString().Length == 1)
                {
                    int rowIndex = currentCell.RowIndex;
                    int columnIndex = currentCell.ColumnIndex;
                    // Increment row/column by whatever logic makes sense for your grid
                    dataGridViewPlatypus.CurrentCell = dataGridViewPlatypus[columnIndex, rowIndex];
                }
            }
        }
        return base.ProcessCmdKey(ref msg, keyData);
    }
