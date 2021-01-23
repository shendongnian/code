    private void DataGrid_Loaded(object sender, RoutedEventArgs e)
    {
       var dataGrid = sender as DataGrid;
       dataGrid.Columns.Clear();
       DataGridTextColumn resourceName = new DataGridTextColumn();
       resourceName.Header = "Name";
       resourceName.Binding = new Binding("ResourceName");
       dataGrid.Columns.Add(resourceName);
       for (int i = 0; i < 10; i++)
       {
           var resourceColumn = new DataGridTextColumn();
           resourceColumn.Header = "Resource " + i;
           resourceColumn.Binding = new Binding(String.Format("ResourceStringList[{0}]", i)) { Mode = BindingMode.TwoWay, UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged };
           dataGrid.Columns.Add(resourceColumn);
       }
    }
