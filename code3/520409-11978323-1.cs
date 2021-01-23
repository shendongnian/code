    dataGridView1.DataSource = your DataSource would be assigned here;
    dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
    dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
    dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
    
    for ( int i = 0; i < dataGridView1.Columns.Count; i++ )
    {
        int colw = grd.Columns[i].Width;
        dataGridView1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
        dataGridView1.Columns[i].Width = colw;
    }
