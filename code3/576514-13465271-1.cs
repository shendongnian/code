            private void Form1_Load(object sender, EventArgs e)
        {
            this.dataGridView1.CellClick += new DataGridViewCellEventHandler(dataGridView1_CellClick);
        }
        public void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            List<object> values = new List<object>();
            int cols = this.dataGridView1.Columns.Count;
            for (int col = 0; col < cols; col++)
            {               
                values.Add(this.dataGridView1[col, e.RowIndex].Value);
            }
        }
