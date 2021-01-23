     private void Form1_Load(object sender, EventArgs e)
            {
                DataGridViewLinkColumn c = new DataGridViewLinkColumn();
                dataGridView1.Columns.Add(c);
                dataGridView1.Rows.Add();
                dataGridView1.Rows[0].Cells[0].Value = "search";
            }
    
            private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
            {
                switch (dataGridView1[e.ColumnIndex,e.RowIndex].Value.ToString())
                {
                    case ("search"):
                        Process.Start("http://www.google.com");
                        break;
                }
            }
