        private void datagridview1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (datagridview1.CurrentCell.ColumnIndex == comboboxcolumnNo && e.Control is ComboBox)
            {
                ComboBox comboBox = (ComboBox)e.Control;
                if (datagridview1.CurrentCell.Value == null)
                {
                    comboBox.SelectedIndex = -1;
                }
            }
        }
