    private static KeyPressEventHandler NumericCheckHandler = new KeyPressEventHandler(NumericCheck);
    private void dataGrid_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
    {
        if (dataGrid.CurrentCell.ColumnIndex == numericColumn.Index)
        {
            e.Control.KeyPress -= NumericCheckHandler;
            e.Control.KeyPress += NumericCheckHandler;
        }
    }
