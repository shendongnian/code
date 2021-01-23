    private void button1_Click(object sender, EventArgs e)
    {
        int x = 0;
        foreach (DataGridViewRow item in this.DataGrid1.SelectedRows)
        {
            DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)item.Cells[1];
            
            if (chk.Value)
            {
                  // codes here for checked condition
            }
            else
            {
                  //code here  for UN-checked condition
            }
          }
         x = x + 1;
     }
