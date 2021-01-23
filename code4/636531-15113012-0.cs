    void centreDataGridView_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
    {
        if (centreDataGridView.Rows[e.RowIndex].IsNewRow)
        {
            return; // do not validate row that has no values
        }
        if (centreDataGridView.Columns[e.ColumnIndex].Name == "code")
        {
            Regex codeRegex = new Regex("^[0-9]{5}[0-9A-Z]$");
            if (!codeRegex.IsMatch(e.FormattedValue.ToString()))
            {
                centreDataGridView.Rows[e.RowIndex].ErrorText = "error text here";
            }
        }
    }
