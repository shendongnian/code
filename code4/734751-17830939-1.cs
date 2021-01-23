    private void dataGridView1_RowValidating(object sender, DataGridViewCellCancelEventArgs e) {
        if (dataGridView1.IsCurrentRowDirty) {
            if (dataCheck())
                if (MessageBox.Show("Ok?", "Save?", MessageBoxButtons.YesNoCancel) == DialogResult.Cancel) {
                    e.Cancel = true;
                }
        }
    }
