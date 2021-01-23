        int rows = 4;
        int cols = 4;
        var uniformGird = new UniformGrid() {Rows = rows, Columns = cols};
        mainGrid.Children.Add(uniformGird);
        var grid = new Grid()
                        {
                            ShowGridLines = true
                        };
        for (int i = 0; i < rows; i++)
        {
            grid.RowDefinitions.Add(new RowDefinition());
        }
        for (int i = 0; i < cols; i++)
        {
            grid.ColumnDefinitions.Add(new ColumnDefinition());
        }
        mainGrid.Children.Add(grid);
