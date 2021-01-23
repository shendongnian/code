    for (int iLoop = 0; iLoop < dtGroup.Columns.Count; iLoop++)
    {
        DataGridTextColumn dgColumn = new DataGridTextColumn();
        dgColumn.Header = dtGroup.Columns[iLoop].ColumnName;
        dgColumn.Binding = new Binding(dtGroup.Columns[iLoop].ColumnName);
        
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
