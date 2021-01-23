    dataGridView.CellFormatting += new DataGridViewCellFormattingEventHandler(dataGridView_CellFormat);
    private void dataGridView_CellFormat(Object sender, DataGridViewCellFormattingEventArgs e)
    {
        if (dataGridView.Columns[e.ColumnIndex].Name.Equals("Time"))
        {
           DateTime dt;
           if (!DateTime.TryParse(e.Value.ToString(), out dt))
           {
               e.Value = "PreviousValue";
           }
        }
    }
