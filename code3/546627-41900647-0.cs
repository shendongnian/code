            int x = 0;
            int y = 0;
            int i = 0;
            int z = 0;
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                
                    if ((dataGridView1.Rows[i].Cells[i].Value) == (dataGridView2.Rows[z].Cells[i].Value))
                    {
                        x++;
                    }
                    else
                    {
                        y++;
                    }
                if (z < dataGridView2.Rows.Count)
                {
                    z++;
                }
                if(z == dataGridView2.Rows.Count)
                {
                    z--; //subtract 1 from the total count because the datagrid is 0 index based.
                }
         MessageBox.Show("Matched: " + x.ToString() + "\r\n" + "Not Matched: " + y.ToString());
