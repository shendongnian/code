    private void grid_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.Modifiers == Keys.Control && e.KeyCode == Keys.A)
        {
            foreach (DataGridViewRow row in grid.Rows)
            {
                row.Selected = row.Visible;
            }
            e.Handled = true;
            e.SuppressKeyPress = true;
        }
    }
