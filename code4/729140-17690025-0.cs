    private void _DataGridView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
    {
        if ((sender as DataGridView).SelectedCells[0].GetType() == typeof(DataGridViewComboBoxCell))
        {
            if ((e.Control as ComboBox) != null)
            {
                (e.Control as ComboBox).SelectedIndexChanged -= new EventHandler(ComboBox_SelectedIndexChanged);
                (e.Control as ComboBox).SelectedIndexChanged += new EventHandler(ComboBox_SelectedIndexChanged);
            }
        }
    }
    private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        if ((sender as ComboBox).SelectedItem.ToString() == "Red")
        {
            _DataGridView.Rows[_DataGridView.CurrentCell.RowIndex].Cells[1].ReadOnly = true;
        }
        else 
        { 
            _DataGridView.Rows[_DataGridView.CurrentCell.RowIndex].Cells[1].ReadOnly = false;  
        }
    }
