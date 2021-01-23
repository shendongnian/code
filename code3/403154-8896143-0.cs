        void AddComboColumn()
        {
            string[] values = { "one", "two", "three" };
            string columnName = "Test";
            var column = new DataGridViewComboBoxColumn();
            column.Name = columnName;
            column.ValueType = typeof(string);
            foreach (string item in values)
            {
                column.Items.Add(item);
            }
            dataGridView1.Columns.Add(column);
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.Cells[columnName].Value = values[2];
            }
        }
