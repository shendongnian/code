        private void dgvSuppliers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgvSuppliers.Rows[e.RowIndex];
                txtID.Text = row.Cells["Supplier ID"].Value.ToString();
                txtName.Text = row.Cells["Supplier Name"].Value.ToString();
                txtTelNo.Text = row.Cells["Telephone No"].Value.ToString();
                txtAddress.Text = row.Cells["Supplier Address"].Value.ToString();
                txtContactName.Text = row.Cells["Contact Name"].Value.ToString();
            }
        }
