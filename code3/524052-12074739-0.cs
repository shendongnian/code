        private void button5_Click(object sender, EventArgs e)
        {
            string[] column1 = new string[dataGridView1.Rows.Count];
            string[] column2 = new string[dataGridView2.Rows.Count];
            int unique = 0;
            bool found = false;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                column1[i] = Convert.ToString(dataGridView1.Rows[i].Cells[2].Value);
            }
            for (int i = 0; i < dataGridView2.Rows.Count; i++)
            {
                column2[i] = Convert.ToString(dataGridView2.Rows[i].Cells[2].Value);
            }
            for (int i = 0; i < column1.Length; i++)
            {
                for (int j = 0; j < column2.Length; j++)
                {
                    if (column1[i] == column2[j])
                    {
                        found = true;
                    }
                }
                if (found == false)
                {
                    unique++;
                }
                found = false;
            }
            MessageBox.Show(unique + " unique strings found!");         
        }
