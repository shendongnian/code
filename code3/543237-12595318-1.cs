    if (richTextBox1.Text != "")
        {
            _parent.dataGridView1.ColumnCount = 3;
            _parent.dataGridView1.Columns[0].Name = "Product ID";
            _parent.dataGridView1.Columns[1].Name = "Product Name";
            _parent.dataGridView1.Columns[2].Name = "Product Price";
            string[] row = new string[] { "1", "Product 1", "1000" };
            _parent.dataGridView1.Rows.Add(row);
            row = new string[] { "2", "Product 2", "2000" };
            _parent.dataGridView1.Rows.Add(row);
            row = new string[] { "3", "Product 3", "3000" };
            _parent.dataGridView1.Rows.Add(row);
            row = new string[] { "4", "Product 4", "4000" };
            _parent.dataGridView1.Rows.Add(row);               
        }
