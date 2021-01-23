        private void datagridview1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (datagridview1.CurrentCell.ColumnIndex == comboboxcolumnNo && e.Control is ComboBox)
            {
                ComboBox combobox = e.Control as ComboBox;
                combobox.SelectedIndex = -1;                
            }
        }
