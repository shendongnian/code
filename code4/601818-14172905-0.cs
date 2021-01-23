    private void dataGridView1_CellValidating(object sender,
    DataGridViewCellValidatingEventArgs e) {
    	if (e.ColIndex == dataGridView.Columns["Item Name"].Index) {
    		dataGridView1.Rows[e.RowIndex].ErrorText = "";
    		int newInteger;
    
    		// Don't try to validate the 'new row' until finished  
    		// editing since there 
    		// is not any point in validating its initial value. 
    		if (dataGridView1.Rows[e.RowIndex].IsNewRow) { return; }
    		if (!int.TryParse(e.FormattedValue.ToString(),
    			out newInteger) || newInteger < 0)
    		{
    			e.Cancel = true;
    			dataGridView1.Rows[e.RowIndex].ErrorText = "the value must be a Positive integer";
    		}
    	}
    }
