        private void gvAppSummary_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (gvAppSummary.CurrentCell.ColumnIndex == intRate)
            {
                e.Control.KeyPress += new KeyPressEventHandler(gvAppSummary_KeyPress);
            }
        }
        private void gvAppSummary_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }
