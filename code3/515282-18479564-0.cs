    private void dataGridView1_CurrentCellDirtyStateChanged( object sender, EventArgs e ) {
        if ( dataGridView1.CurrentCell is DataGridViewCheckBoxCell ) {
            DataGridViewCheckBoxCell cb = (DataGridViewCheckBoxCell)dataGridView1.CurrentCell;
            if ( (byte)cb.Value == 1 ) {
                dataGridView1.CurrentRow.Cells["time_loadedCol"].Value = DateTime.Now.ToString();
            }
        }
        dataGridView1.EndEdit();
    }
    
