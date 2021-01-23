       private void Form1_Load(object sender, EventArgs e)
        {
            DataGridViewCheckBoxColumn checkBox = new DataGridViewCheckBoxColumn(true);
            checkBox.HeaderText = "T/F";
            dataGridView1.Columns.Add(checkBox);
           
        }
        private void button1_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[0];
                if (Convert.ToBoolean(chk.Value) == true)
                {
                    MessageBox.Show("Value Is True");
                }
            }
        }
