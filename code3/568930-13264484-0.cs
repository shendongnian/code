    for (int i = 0; i < dataGridView1.Rows.Count-1; i++)
      {
    
         if (Convert.ToInt16(dataGridView1.Rows[i].Cells[0].Value) > 0)
            {
    
            DataGridViewCellStyle CellStyle = new DataGridViewCellStyle();
            CellStyle.BackColor = Color.Red;
            dataGridView1.Rows[i].Cells[0].Style = CellStyle;
            }
      }
