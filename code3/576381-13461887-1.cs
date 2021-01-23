            IList<double> kvChoices;
            // Populate kvChoices...
            DataGridViewComboBoxColumn kvCol =
                dataGridView1.Columns[0] as DataGridViewComboBoxColumn;
            kvCol.DataSource = kvChoices;
            kvCol.ValueType = typeof(double);
