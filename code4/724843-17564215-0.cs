    private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
            Column_handling();
            if (e.ColumnIndex == 10)
            {
                DataRow dt = datarows.NewRow();
                //fillign vlaues
                datarows.Rows.InsertAt(dt, e.RowIndex + 1);
    
                var row = this.dataGridView1.Rows[e.RowIndex + 1];
                var cell = new DataGridViewTextBoxCell();
                cell.Value = string.Empty;
                row.Cells["ButtonColumnName"] = cell;
                cell.ReadOnly = true;
    
                dataGridView1.Refresh();
            }
    }
