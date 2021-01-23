    private void dataGridView_SelectionChanged(object sender, EventArgs e)
    {
        DataGridViewCell cell = null;
        foreach (DataGridViewCell selectedCell in dataGridView.SelectedCells)
        {
            cell = selectedCell;
            break;
        }
        if (cell != null)
        {
            DataGridViewRow row = cell.OwningRow;
            idTextBox.Text = row.Cells["ID"].Value.ToString();
            nameTextBox.Text = row.Cells["Name"].Value.ToString();
            // etc.
        }
    }
