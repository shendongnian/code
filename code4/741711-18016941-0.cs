            // Columns
        this.Grid.ColumnDefinitions.Add(new ColumnDefinition());
        ColumnDefinition col = new ColumnDefinition();
        col.Width = new GridLength(100, GridUnitType.Star);
        this.Grid.ColumnDefinitions.Add(col);
        this.Grid.ColumnDefinitions.Add(new ColumnDefinition());
        // Rows
        this.Grid.RowDefinitions.Add(new RowDefinition());
        this.Grid.RowDefinitions.Add(new RowDefinition());
        this.Grid.RowDefinitions.Add(new RowDefinition());
