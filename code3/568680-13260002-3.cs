    private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.ColumnIndex != 0)
        {
            if (Double.Parse(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()) <= Double.Parse(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex - 1].Value.ToString()))
            {
                MessageBox.Show("Please verify the value");
            }
        }
    }
