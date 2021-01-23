    foreach (DataGridViewRow rw in this.dataGridView1.Rows)
    {
        if (rw.Cells.Count > 2 && 
            rw.Cells[0].Value != DBNull.Value && String.IsNullOrWhiteSpace(rw.Cells[0].Value.ToString()) &&
            ((bool)rw.Cells[0].Value) &&
                rw.Cells[1].Value != DBNull.Value && String.IsNullOrWhiteSpace(rw.Cells[1].Value.ToString()))
        {
                s.delete(Convert.ToInt32(rw.Cells[1].Value));
    
        }
    }
