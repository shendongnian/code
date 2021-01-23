    private void ChangeOtherCellColor()
     {
      if(IsAnyGreaterThanZero)
      {
        for (int i = 0; i < dataGridView1.Rows.Count-1; i++)
          {
            if ((int)intdataGridView1.Rows[i].Cells[0].Value == 0)
            {
                DataGridViewCellStyle CellStyle = new DataGridViewCellStyle();
                CellStyle.BackColor = Color.Red;
                dataGridView1.Rows[i].Cells[0].Style = CellStyle;
            }
          }
       }
    
    
      }
