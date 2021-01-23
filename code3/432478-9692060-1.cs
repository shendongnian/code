    private void button2_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow dr in dataGridView1.Rows)
            {
                string lngth = Convert.ToString(dr.Cells[1].Value);
                if (lngth.Length > 0)
                {
                    listBox1.Items.Add(dr.Cells[0].Value);
                }
            }
        }
