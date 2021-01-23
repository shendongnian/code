    private void dgMAQ_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
    DependencyObject dep = (DependencyObject)e.EditingElement;
                string newText = string.Empty;
            //Check if the item being edited is a textbox
            if (dep is TextBox)
            {
                TextBox txt = dep as TextBox;
                if (txt.Text != "")
                {
                    newText = txt.Text;
                }
                else
                {
                    newText = string.Empty;
                }
            }
            //New text is the new text that has been entered into the cell
           //Check that the value is what you want it to be
            double isDouble = 0;
            if (double.TryParse(newText, out isDouble) == true)
            {
                while ((dep != null) && !(dep is DataGridCell))
                {
                    dep = VisualTreeHelper.GetParent(dep);
                }
                if (dep == null)
                    return;
                if (dep is DataGridCell)
                {
                    DataGridCell cell = dep as DataGridCell;
                    // navigate further up the tree
                    while ((dep != null) && !(dep is DataGridRow))
                    {
                        dep = VisualTreeHelper.GetParent(dep);
                    }
                    if (dep == null)
                        return;
                    DataGridRow row = dep as DataGridRow;
                    int rowIndex = row.GetIndex();
                    
                    int columnIndex = cell.Column.DisplayIndex;
			//Check the column index. Possibly different save options for different columns
                    if (columnIndex == 3)
                    {
                        
                        if (newText != string.Empty)
                        {
                            //Do what you want with newtext
                        }
                    }
    }
