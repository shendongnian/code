        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == r)
            {
                if (e.ColumnIndex == c)
                {
                    dataGridView1.Columns[e.ColumnIndex].ReadOnly = true;
                }
            }
        }
        private void dataGridView1_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == r)
            {
                if (e.ColumnIndex == c)
                {
                    dataGridView1.Columns[e.ColumnIndex].ReadOnly = false;
                }
            }
        }
