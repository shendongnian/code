    private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
            {
                int colIndex = e.ColumnIndex;
                int rowIndex = e.RowIndex;
    
                if (rowIndex >= 0 && colIndex >= 0)
                {
                    DataGridViewRow theRow = dataGridView1.Rows[rowIndex];
    
                    int difference = (int)theRow.Cells[5].Value;
               
                    if (difference <= 0)
                    {
                        theRow.DefaultCellStyle.BackColor = System.Drawing.Color.Red;
                        theRow.DefaultCellStyle.ForeColor = System.Drawing.Color.White;
                    }
                }
    
            }
