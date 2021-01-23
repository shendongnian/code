        string str = null;
        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            var cell = e.Control as ComboBox;
            if (cell != null)
            {
                cell.SelectedIndexChanged -= doWork;
                cell.SelectedIndexChanged += doWork;
            }
        }
        private void doWork(object sender, EventArgs e)
        {
            var tb = dataGridView1.EditingControl as ComboBox;
            if (tb != null)
                str = tb.SelectedValue != null ? tb.SelectedValue.ToString() : null;
        }
