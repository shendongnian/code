    DataTable Dt = new DataTable();
    Dt.Columns.Add("Column1");
    Dt.Columns.Add("Column2");
    DataRow dr = Dt.NewRow();
    DataGridViewRow dgvR = (DataGridViewRow)dataGridView1.CurrentRow;
    dr[0] = dgvR.Cells[0].Value; 
    dr[1] = dgvR.Cells[1].Value;              
         
    Dt.Rows.Add(dR);
    dataGridView1.DataSource = Dt;
