        private void _GotoNext(object sender, EventArgs e)
        {
            int currentRow = DataGridView1.SelectedRows[0].Index;
            if (currentRow < DataGridView1.RowCount - 1)
            {
                DataGridView1.Rows[++currentRow].Cells[0].Selected = true;
            }
        }
        private void _GotoPrev(object sender, EventArgs e)
        {
            int currentRow = DataGridView1.SelectedRows[0].Index;
            if (currentRow > 0)
            {
                DataGridView1.Rows[--currentRow].Cells[0].Selected = true;
            }
        }
