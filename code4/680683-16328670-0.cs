        private void dataGridView1_CellClick(object sender, 
                                             DataGridViewCellEventArgs e)
        {
            for (int index = 0; index < dataGridView1.Rows.Count; index++)
            {
                DataGridViewRow dr = dataGridView1.Rows[index];
                if (index == dataGridView1.CurrentCell.RowIndex)
                {
                    DataGridViewTextBoxCell txtCell = new DataGridViewTextBoxCell();
                    dr.Cells[0] = txtCell;
                }
                else
                {
                    DataGridViewButtonCell buttonCell = new DataGridViewButtonCell();
                    dr.Cells[0] = buttonCell;
                }
            }
        }
    }
