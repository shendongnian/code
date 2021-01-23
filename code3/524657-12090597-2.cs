    for (int counter = 0; counter < dtGroup.Columns.Count; counter++)
    {
        DataGridTextColumn dgColumn = new DataGridTextColumn();
        dgColumn.Header = dtGroup.Columns[counter].ColumnName;
        dgColumn.Binding = new Binding(dtGroup.Columns[counter].ColumnName);
        
        Style columnStyle = new Style(typeof(TextBlock));
        Trigger backgroundColorTrigger = new Trigger();
        backgroundColorTrigger.Property = TextBlock.TextProperty;
        backgroundColorTrigger.Value = "V31";
        backgroundColorTrigger.Setters.Add(
            new Setter(
                TextBlock.BackgroundProperty,
                new SolidColorBrush(Colors.LightGreen)));
        columnStyle.Triggers.Add(backgroundColorTrigger);
        dgColumn.ElementStyle = columnStyle;
        this.dgGroupMatrix.Columns.Add(dgColumn);
    }
