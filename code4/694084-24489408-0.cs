    private void dgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        if (dgvProducts.SelectedCells.Count > 0) // Checking to see if any cell is selected
        {
            int mSelectedRowIndex = dgvProducts.SelectedCells[0].RowIndex;
            DataGridViewRow mSelectedRow = dgvProducts.Rows[mSelectedRowIndex];
            string mProductName = Convert.ToString(mSelectedRow.Cells[1].Value); //put your columb index where the 1 is 
            dgvProducts.CurrentCell.Value = null; // removes value from current cell
            SomeOtherMethod(mProductName); // Passing the name to where ever you need it
            UpdateDataBaseMethod(dgvProducts); // You can do that bit
        }
    }
