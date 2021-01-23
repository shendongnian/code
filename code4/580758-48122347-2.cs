    // This snippet is much safer in terms of preventing unwanted
    // Exceptions because of missing [DisplayNameAttribute].
    private void DataGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
    {
        if (e.PropertyDescriptor is PropertyDescriptor descriptor)
        {
            e.Column.Header = descriptor.DisplayName ?? descriptor.Name;
        }
    }
