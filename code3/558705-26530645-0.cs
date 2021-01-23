    private void datagridview_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            bool validRow = (e.RowIndex != -1); //Make sure the clicked row isn't the header.
            var datagridview = sender as DataGridView;
            
            // Check to make sure the cell clicked is the cell containing the combobox 
            if(datagridview.Columns[e.ColumnIndex] is DataGridViewComboBoxColumn && validRow)
            {
                datagridview.BeginEdit(true);
                ((ComboBox)datagridview.EditingControl).DroppedDown = true;
            }
        }
