    private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e) {
        // Check if wanted column was clicked 
        if (e.ColumnIndex == dataGridView1.Columns[BUTTON_COLUMN_INDEX].Index && e.RowIndex >= 0) {
            //Perform on button click code
        }
    }
