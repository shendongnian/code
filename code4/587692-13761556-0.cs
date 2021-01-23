    private void DataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
            {
                if (DataGridView1.CurrentCell.ColumnIndex == yourComboBoxColum)
                {
    
                    ComboBox combo = e.Control as ComboBox;
    
                    combo.DropDownStyle = ComboBoxStyle.DropDown;
    
                    if (combo == null)
                        return;
    
                }
            }
