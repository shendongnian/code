    void centreDataGridView_CellValidating(object sender, 
        DataGridViewCellValidatingEventArgs e)
    {
        centreDataGridView.Rows[e.RowIndex].ErrorText = string.Empty;
        if (centreDataGridView.Columns[e.ColumnIndex].Name == "code")
        {
            if (!(centreDataGridView.Rows[e.RowIndex].IsNewRow) || 
                (e.FormattedValue.ToString() != string.Empty))
            {
                Regex codeRegex = new Regex("^[0-9]{5}[0-9A-Z]$");
                if (!codeRegex.IsMatch(e.FormattedValue.ToString()))
                {
                    centreDataGridView.Rows[e.RowIndex].ErrorText = "blah blah blah";
                }
            }
        }
    }
