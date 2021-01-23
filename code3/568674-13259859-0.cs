    private void datagridview_CellValidating(object sender, CellValidatingEventArgs e) {
        // This is the new proposed value the user entered; could be for column 3 or 4.
        int newValue = int.Parse(e.FormattedValue.ToString());
        
        // See which column fired the CellValidating event and use the new proposed value for it
        // in place of the cell's actual value for purposes of our validation.
        int col3Value = (e.ColumnIndex == 2) ? newValue : (int)dataGridView1[2, e.RowIndex].Value;
        int col4Value = (e.ColumnIndex == 3) ? newValue : (int)dataGridView1[3, e.RowIndex].Value;
   
        if (col3Value <= col4Value) {
            MessageBox.Show("Please verify the value");
            e.Cancel = true;
        }
    }
