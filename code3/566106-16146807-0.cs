    void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
    {
        foreach (DataGridViewRow r in dataGridView1.Rows)
        {
            if (System.Uri.IsWellFormedUriString(r.Cells["Links"].Value.ToString(), UriKind.Absolute))
            {
                r.Cells["Links"] = new DataGridViewLinkCell();
                DataGridViewLinkCell c = r.Cells["Links"] as DataGridViewLinkCell;
            }
        }
    }
    
    // And handle the click too
    private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
    	if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex] is DataGridViewLinkCell)
    	{
    		System.Diagnostics.Process.Start( dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value as string);
    	}
    }
