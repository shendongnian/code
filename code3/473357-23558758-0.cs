    // validation on dgvLotDetail's Yield Column (only numeric and between 0 to 100 allowed)
        private void dgvLotDetail_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (dgvLotDetail.Rows[e.RowIndex].Cells[txtYield.Index].Value != null)
            {
                if (e.ColumnIndex == txtYield.Index)
                {
                    int i;
                    if ( !int.TryParse(Convert.ToString(e.FormattedValue), out i) ||
                        i < 0 ||
                        i > 100 )
                    {
                        e.Cancel = true;
                        MessageBox.Show("Enter only integer between 0 and 100.");
                    }
                    else
                    {
                    }
                }
            }
        }
