            DataTable table = new DataTable("Customers");
            // copy the correct structure from datagridview to the table
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                table.Columns.Add(column.Name, typeof(string));
            }
            // populate the datatable from datagridview
            for (int rowIndex = 0; rowIndex < dataGridView1.Rows.Count; rowIndex++)
            {
                table.Rows.Add();
                for (int columnIndex = 0; columnIndex < dataGridView1.Columns.Count; columnIndex++)
                {
                    table.Rows[rowIndex][columnIndex] = dataGridView1[rowIndex, columnIndex].Value;
                }
            }
