    private void dataGridView_CellValidating(object sender,
    DataGridViewCellValidatingEventArgs e)
    {
        if (!DateTime.TryParse(e.FormattedValue))
        {
             string s = e.FormattedValue;
             e.Cancel = true;
        }
    }
