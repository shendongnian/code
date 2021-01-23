    int RowIndex = 0;
    private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
    {
        if (dataGridView1.CurrentRow == null)
            return;           
    
        if (e.Button == MouseButtons.Right)
        {
            RowIndex = dataGridView1.CurrentRow.Index ;               
        }
    }
    
    private void testToolStripMenuItem_Click(object sender, EventArgs e) //MenuStrip item click event
    {
        if (RowIndex == 0)
        {
    
        }
        else if (RowIndex == 1)
        {
    
        }
    }
