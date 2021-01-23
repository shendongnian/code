    void ColorGrid()
    {
         foreach (GridViewRow row in dataGridView1.Rows) 
         {
            if (row.Cells[5].Text == "ok") 
            {
                row.BackColor = Color.Green; 
            }
            else
            {
                row.BackColor = Color.Red; 
            }
         }
    }
