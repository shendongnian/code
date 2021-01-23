    private void button1_Click(object sender, EventArgs e) 
    {
      List ChkedRow = new List <String>();
      for(int i=0; i < dataGridView1.Rows.Count; i++)
       {
         DataGridViewCheckBoxCell chkBox = (DataGridViewCheckBoxCell)dataGridView1.Rows[i].Cells[0];
         if ((Boolean)chkBox.FormattedValue)
            {
             ChkedRow.Add(i);
            }
       }
      if (ChkedRow.Count == 0)
      {
         MessageBox.Show("Select atleast one checkbox");
         return;
      }
      foreach (int k in ChkedRow)
      {
         textBox1.Text += dataGridView1.Rows[k].Cells[1].Value.ToString()+ " - ";
      }
    }
