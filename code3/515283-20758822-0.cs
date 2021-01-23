    private void dgvProducts_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvProducts.DataSource != null)
            {
                if (dgvProducts.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == "True")
                {
                    //do something
                }
                else
                {
                   //do something
                }
            }
        }
