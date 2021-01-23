    void dataGridView1_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
    {
        int parsedValue = 0;
        if (!int.TryParse(e.Value.ToString(), out parsedValue))
        {
            if (int.TryParse(dataGridView1[e.ColumnIndex, e.RowIndex].Value.ToString(), out parsedValue))
                e.Value = parsedValue;
            else
                e.Value = 0;
            e.ParsingApplied = true;
        }
    } 
