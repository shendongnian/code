     private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.CellContentClick += new DataGridViewCellEventHandler(dataGridView1_CellContentClick);
            DataGridViewButtonColumn select = new DataGridViewButtonColumn();
            select.Text = "Details";
            select.HeaderText = "Details";
            select.Name = "Select";
            dataGridView1.Columns.Add(select);
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["Select"].Index)
            {
                MessageBox.Show(String.Format("Clicked! Row: {0}", e.RowIndex));
            }
        }
