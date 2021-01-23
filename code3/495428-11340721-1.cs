        private void dataGridView1_EditingControlShowing(object sender, 
                                   DataGridViewEditingControlShowingEventArgs e)
        {
            if (dataGridView1.CurrentCell.ColumnIndex == 1)
            {
                e.CellStyle.Format = "#";
                e.Control.Text = dataGridView1.CurrentCell.Value.ToString();
            }
        } 
