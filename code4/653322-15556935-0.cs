    private void DataGrid_BeginningEdit(object sender, DataGridBeginningEditEventArgs e)
    {
        RowViewModel VM = (RowViewModel)((DataGrid)sender).SelectedItem;
        if (!VM.IsRetail) { e.Cancel = true; }
    }
