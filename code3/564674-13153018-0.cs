    You can use CellValidating event of DataGridView.
    private void dataGridView1_CellValidating(object sender,
            DataGridViewCellValidatingEventArgs e)
        {
            // Validate the Price entry.
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Price")
            {
            }
        }
