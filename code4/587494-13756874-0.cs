    private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
            {
                ComboBox nameComboBox = e.Control as ComboBox;
                if (dataGridView1.CurrentCell.ColumnIndex == 0)
                {
                    if (nameComboBox != null)
                    {
                        ((ComboBox)e.Control).DropDownStyle = ComboBoxStyle.DropDown;
                        ((ComboBox)e.Control).AutoCompleteSource = AutoCompleteSource.ListItems;
                        ((ComboBox)e.Control).AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
                    }
                }
            }
    
    
            private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
            {
                if (dataGridView1.IsCurrentCellDirty)
                {
                    dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
                    if (e.ColumnIndex == 0)
                    {
                        //Your codes here
                    }
                }
            }
