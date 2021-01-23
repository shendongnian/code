        private void dataGridView1_Sorted(object sender, System.EventArgs e)
        {
            foreach (DataGridViewRow dataGridViewRow in
                                     dataGridView1.Rows.Cast<DataGridViewRow>())
            {
                dataGridViewRow.Cells["Order"].Value = dataGridViewRow.Index + 1;
            }
        }
