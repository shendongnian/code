            DataGridViewComboBoxColumn col = new DataGridViewComboBoxColumn();
            col.HeaderText = "Name";
            col.Name = "Name";
            col.DataSource = ds.Tables[0];
            col.DisplayMember = ds.Tables[0].Columns[1].ToString();
            dataGridView1.Columns.Add(col);
