    datagridview.EditingControlsShowing += datagridview_EditingControls;
    datagridview_EditingControls(object sender,DataGridViewEditingControlShowingEventArgs e)
    {
      e.control.KeyDown += Control_KeyDown;
    }
    private void Control_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dataGridView.CurrentCell = dataGridView.CurrentRow.Cells[e.ColumnIndex + 1];
            }
        }
