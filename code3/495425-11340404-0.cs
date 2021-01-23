    void DataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
        if (e.ColumnIndex == 1)
        {
            int value;
            if(e.Value != null && int.TryParse(e.Value.ToString(), out value))
            {
                e.Value = value.ToString("#mm");
            }
        }
    }
