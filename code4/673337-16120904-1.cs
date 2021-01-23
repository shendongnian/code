    var datagrid = new DataGrid();
    datagrid.Style = FindResource("ReadOnlyGridStyle") as Style;
    datagrid.Columns.Add(new DataGridTextColumn()
    {
        Header = "Type",
        Width = new DataGridLength(200),
        FontSize = 12,
        Binding = new Binding("Name")
    });
    datagrid.Columns.Add(new DataGridTemplateColumn()
    {
        Header = "Ingredients",
        Width = new DataGridLength(1, DataGridLengthUnitType.Star),
        CellTemplate = FindResource("IngredientsCellTemplate") as DataTemplate
    });
    datagrid.ItemsSource = ...
