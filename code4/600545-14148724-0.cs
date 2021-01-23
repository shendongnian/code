    private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
    {
        foreach (DataGridViewRow row in dataGridView1.Rows)
        {
            if(!string.IsNullOrEmpty(row.Cells[3].Value.ToString()))  // make sure the value is present
            (
              if (row.Cells[3].Value.ToString() == "0") 
              {
                  row.DefaultCellStyle.BackColor = Color.Red;  //then change row color to red
              }
            )
        }
    }
