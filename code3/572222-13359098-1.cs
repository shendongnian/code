    StringBuilder sb = new StringBuilder();
    for (int i = 0; i < dataGridView4.Rows.Count - 1; i++)
    {
         if (dataGridView4.Rows[i].Cells["ABC"].Value.ToString() != "")
         {
    
               sb.Append("ABC_ " + dataGridView4.Rows[i].Cells["ABC"].Value.ToString()
                        + " " + dataGridView4.Rows[i].Cells["DEF"].Value.ToString().Replace("\n", "") + ";");
         }
    }
    richTextBox1.Text = sb.ToString();
