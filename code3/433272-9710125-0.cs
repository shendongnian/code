    Binding binding = new Binding("Visibility");
    binding.Source = buildingFieldList.Single(x => x.FieldName == columnName);
    DataGridTextColumn column = 
        new DataGridTextColumn()    
        {    
            Header = columnName,    
            Binding = new Binding("results[" + columnName + "]"),    
            CanUserSort = true,    
        };
    BindingOperations.SetBinding(column, DataGridColumn.VisibilityProperty, binding);
