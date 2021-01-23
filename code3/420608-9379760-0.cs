    DataGridTemplateColumn changeRumStyleColumn = new DataGridTemplateColumn();
    changeRumStyleColumn.Header = headerRumStyle;
    FrameworkElementFactory styleComboFactory = 
        new FrameworkElementFactory(typeof(ComboBox));
    Binding selectedStyle = new Binding("rumStyleDesc");
    styleComboFactory.SetBinding(ComboBox.ItemsSourceProperty,
        new Binding("rumStlyesList"));
    styleComboFactory.SetBinding(ComboBox.SelectedItemProperty, new Binding("rumStyleDesc"));
    styleComboFactory.SetValue(ComboBox.SelectedItemProperty, selectedStyle);
    styleComboFactory.AddHandler(ComboBox.SelectionChangedEvent, 
    new SelectionChangedEventHandler(comboBox1_SelectionChanged));
    DataTemplate rumStyleTemplate = new DataTemplate();
    rumStyleTemplate.VisualTree = styleComboFactory;
    changeRumStyleColumn.CellTemplate = rumStyleTemplate;
    _dgData.Columns.Add(changeRumStyleColumn);
