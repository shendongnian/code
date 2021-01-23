    var cellTemplate = (DataTemplate)XamlReader.Load(...);
    var cellEditTemplate = (DataTemplate)XamlReader.Load(...);
    for(...)
    {
       //..
       column.CellTemplate = cellTemplate;
       column.CellEditingTemplate = cellEditTemplate;
       //...
    }
