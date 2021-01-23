      private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewCellStyle CellStyle = new DataGridViewCellStyle();
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor == Color.Red)
            {
                CellStyle.BackColor = Color.White;
                dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Style = CellStyle;
            }
            else
            {
              
                CellStyle.BackColor = Color.Red;
                dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Style = CellStyle;
            }
        }
