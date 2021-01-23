    private void datagridview1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (e.Control is ComboBox)                
            {
                ComboBox comboBox = (ComboBox)e.Control;
                if (datagridview1.CurrentCell.Value == null
                    || string.IsNullOrEmpty(datagridview1.CurrentCell.Value.ToString())
                    || string.IsNullOrEmpty(comboBox.SelectedText)
                    )
                {
                    comboBox.SelectedIndex = -1;
                }               
            }
        }
