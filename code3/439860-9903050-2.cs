     RowDetailsVisibilityChangedCommand = new RelayCommand<DataGridRowDetailsEventArgs>(e =>
    {
       DataGrid SpoolsDataGrid = e.DetailsElement as DataGrid;
       DataRowView drv = (DataRowView)e.Row.Item;
       serialNo = drv.Row["BOX_SERIAL"].ToString();
       SpoolsDataGrid.ItemsSource = as400Service.GetSPOOL_BY_SERIAL_NO(serialNo);
     });
