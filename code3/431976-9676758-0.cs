        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                int col = dataGridView1.CurrentCell.ColumnIndex;
                int row = dataGridView1.CurrentCell.RowIndex;
                if (col < dataGridView1.ColumnCount - 1)
                {
                    col ++;
                }
                else
                {
                    col = 0;
                    row++;
                }
                if (Row == dataGridView1.RowCount)
                    dataGridView1.Rows.Add();
                
                dataGridView1.CurrentCell = dataGridView1[col, row];
                e.Handled = true;
            }
        }
