    int rowsCount = dataGridView1.Rows.Count;
            string cuurentTime = DateTime.Now.ToString("HH:mm:ss");
            if (cuurentTime != dataGridView1.Rows[rowsCount - 1].Cells[0].Value.ToString())
            {
                dataGridView1.Rows.Add(new string[] { cuurentTime, textBox1.Text, textBox2.Text });
            }
 
