    private void DataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
    {
        if (DataGridView1.CurrentCell.ColumnIndex == yourComboBoxColum)
        {
            ComboBox combo = e.Control as ComboBox;
            
            if (combo == null)
                return;
            
            combo.DropDownStyle = ComboBoxStyle.DropDown;
        }
    }
