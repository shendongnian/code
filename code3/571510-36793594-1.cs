    private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
    {
    	if (dgv.CurrentRow.Cells["ColumnNumber"].Value != null && (bool)dgv.CurrentRow.Cells["ColumnNumber"].Value)
	    {
		    dgv.CurrentRow.Cells["ColumnNumber"].Value = false;
    		dgv.CurrentRow.Cells["ColumnNumber"].Value = null;
	    }
    	else if (dgv.CurrentRow.Cells["ColumnNumber"].Value == null )
	    {
		    dgv.CurrentRow.Cells["ColumnNumber"].Value = true;
    	}
    }
