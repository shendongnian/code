            dataGridView1.Columns.Add(new DataGridViewImageColumn());
            dataGridView1.Rows.Add(2);
            DataGridViewImageCell cell = (DataGridViewImageCell)dataGridView1.Rows[0].Cells[0];
            Icon ic = new Icon("icon.ico");
            cell.Value = ic;
