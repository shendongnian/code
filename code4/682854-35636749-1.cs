    private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0) {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                iD_supplierNumericUpDown.Value = row.Cells["ID"].Selected(); // this is the problem
                nSupplierTextBox.Text = row.Cells["NSupplier"].Value.ToString();
                e_mailTextBox.Text = row.Cells["E_mailTextBox"].Value.ToString();
                phoneTextBox.Text = row.Cells["Phone"].Value.ToString();
            }
