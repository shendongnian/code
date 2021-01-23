    private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
            {
                e.SuppressKeyPress = true;
                int iColumn = dataGridView1.CurrentCell.ColumnIndex;
                int iRow = dataGridView1.CurrentCell.RowIndex;
                if (iColumn == dataGridView1.Columncount-1)
                {
                    if (dataGridView1.RowCount > (iRow + 1))
                    {
                        dataGridView1.CurrentCell = dataGridView1[1, iRow + 1];
                    }
                    else
                    {
                       //focus next control
                    }
                }
                else
                  
                    dataGridView1.CurrentCell = dataGridView1[iColumn + 1, iRow];
         
            }
            }
