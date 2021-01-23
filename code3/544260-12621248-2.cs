    foreach(DataGridViewRow r in dataGridView1.Rows)
    {
          if(r.Cells.Cast<DataGridViewCell>().Any(c => c.Value.ToString() == string.Empty)) 
          {
               r.DefaultCellStyle.BackColor = Color.Violet;
          }
    }
