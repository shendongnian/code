    foreach (DataGridViewRow dgvrow in dataGridView1.SelectedRows) {
        string study = dgvrow.Cells[2].Value.ToString();
        txtcellvalue.Text = dgvrow.Cells[3].Value.ToString();
        txtcellvalue1.Text = dgvrow.Cells[4].Value.ToString();
        string unit = dgvrow.Cells[5].Value.ToString();
        if (MessageBox.Show("Would like to update the click yes!!",
            "values", MessageBoxButtons.YesNo) ==
            System.Windows.Forms.DialogResult.Yes) {
                // ETC...
        }
        else {  }
    }
