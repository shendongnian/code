     private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.ColumnCount = 3;
            dataGridView1.Columns[0].Name = "Name";
            dataGridView1.Columns[1].Name = "Age";
            dataGridView1.Columns[2].Name = "City";
            dataGridView1.Rows.Add("kathir", "25", "salem");
            dataGridView1.Rows.Add("vino", "24", "attur");
            dataGridView1.Rows.Add("maruthi", "26", "dharmapuri");
            dataGridView1.Rows.Add("arun", "27", "chennai"); 
        }
