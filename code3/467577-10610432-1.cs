    private void _onDataGrid1SelectionChanged(object sender, SelectedCellsChangedEventArgs e) {
       if (e.AddedCells.Count > 0) {
            var props = new Collection<PropertyModel>();
            var obj = _dataGrid1.SelectedItem;
            foreach(var prop in obj.GetType().GetProperties()) {
                props.Add(new PropertyModel(prop.Name, prop.GetValue(obj, null)));
            }
            
            _dataGrid2.ItemsSource = props;
       }
    }
