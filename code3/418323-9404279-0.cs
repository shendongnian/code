    DataGridTextColumn l_column = new DataGridTextColumn();
    l_column.Header = l_columnName;
    l_column.Binding = new Binding(l_columnName);
    l_column.Width = l_iWidth;
    Style l_textStyle = new Style(typeof(TextBlock));
    l_textStyle.Setters.Add(new Setter(TextBlock.TextWrappingProperty, TextWrapping.Wrap));
    l_column.ElementStyle = l_textStyle;
    Style l_textEditStyle = new Style(typeof(TextBox));
    l_textEditStyle.Setters.Add(new Setter(TextBox.TextWrappingProperty, TextWrapping.Wrap));
    l_column.EditingElementStyle = l_textEditStyle;
        
    dataGrid.Columns.Add(l_column);
