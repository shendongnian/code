    private void cmdPopulate_Click(object sender, EventArgs e)
        {
            if (dataGridView1.ColumnCount > 0)
            {
                dataGridView1 = new DataGridView();
            }
            DataTable dt = new DataTable();
            dt.Columns.Add("number");
            dt.Columns.Add("name");
            dt.Columns.Add("image");
            dt.Rows.Add(new object[] { "Item 1","Apple","" });
            dt.Rows.Add(new object[] { "Item 2", "Orange", "" });
            dt.Rows.Add(new object[] { "Item 3", "Banana", "" });
            dataGridView1.DataSource = dt.DefaultView;
        }
