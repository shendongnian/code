    private void DataGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
    {
        string header = e.Column.Header.ToString();
    
        // Replace all underscores with two underscores, to prevent AccessKey handling
        e.Column.Header = header.Replace("_", "__");
    }
