    void ColorGrid()
    {
         foreach (DataGridViewRow row in dataGridView1.Rows) 
         {
            if (row.Cells[5].Text == "ok") 
            {
                row.DefaultCellStyle.BackColor = Color.Green; 
            }
            else
            {
                row.DefaultCellStyle.BackColor = Color.Red; 
            }
         }
    }
