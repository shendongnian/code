    private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
    {
            if (e.ColumnIndex<0||e.RowIndex<0)
            {
               return;
            }
            DataGridViewCell cell = dataGridView1[e.ColumnIndex, e.RowIndex];
            if (cell is DataGridViewButtonCell)
            {
                MessageBox.Show("Test");
            } 
        }
