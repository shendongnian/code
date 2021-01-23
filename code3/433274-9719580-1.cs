    Binding testBind = new Binding();
    testBind.Mode = BindingMode.TwoWay;
    testBind.Source = buildingFieldList.Single(x => x.FieldName == columnName);
    testBind.Path = new PropertyPath("Visibility");
    ExtendedDataGridTextColumn temp = new ExtendedDataGridTextColumn()
        {
	    Header = columnName,
	    Binding = new Binding("results[" + columnName + "]"),
        CanUserSort = true
        };
    BindingOperations.SetBinding(temp, ExtendedDataGridTextColumn.ColumnVisibilityProperty, testBind);
    ResultsGrid.Columns.Add(temp);
