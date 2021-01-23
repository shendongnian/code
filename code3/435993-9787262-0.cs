    private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e) {
            // insert additional checks to fit your constraints
            if (dataGridView1.CurrentCell.IsInEditMode) {
                int value;
                if (!int.TryParse(e.FormattedValue.ToString(), out value)) {
                    MessageBox.Show("Must be integer!");
                    e.Cancel = true;
                }
            }
        }
