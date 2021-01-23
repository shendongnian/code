    // Columns
    this.Grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = GridLength.Auto });
    this.Grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(100, GridUnitType.Star) });
    this.Grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = GridLength.Auto });
    
    // Rows
    this.Grid.RowDefinitions.Add(new RowDefinition() { Height = GridLength.Auto });
    this.Grid.RowDefinitions.Add(new RowDefinition() { Height = GridLength.Auto });
    this.Grid.RowDefinitions.Add(new RowDefinition() { Height = GridLength.Auto });
