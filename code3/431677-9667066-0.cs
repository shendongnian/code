    private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
            {
                if (e.KeyCode == Keys.Enter)
                {                
                    e.SuppressKeyPress=true;
                    int iColumn = dataGridView1.CurrentCell.ColumnIndex;
                    int iRow = dataGridView1.CurrentCell.RowIndex;
                    if (iColumn == dataGridView1.Columns.Count-1)
                        dataGridView1.CurrentCell = dataGridView1[0, iRow + 1];
                    else
                        dataGridView1.CurrentCell = dataGridView1[iColumn + 1, iRow];
    
                }
            }
