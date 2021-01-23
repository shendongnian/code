        private void myDataGridView_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            // Get current row.
            DataGridViewRow obj = myDataGridView.CurrentRow;
            // Get the cell with the checkbox.
            DataGridViewCheckBoxCell oCell = obj.Cells[theIndexOfTheCheckboxColumn] as DataGridViewCheckBoxCell;
            // Check the value for null.
            if (oCell.Value.ToString().Equals(string.Empty))
                oCell.Value = true;
        }
