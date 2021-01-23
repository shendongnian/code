    private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
        // If the column is the Time column, check the 
        // value. 
        if (this.dataGridView1.Columns[e.ColumnIndex].Name == "Time")
        {
            if (e.Value != null)
            {
                 //Your implementation.
            }
        }
    }
