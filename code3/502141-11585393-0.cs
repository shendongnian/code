    Grid grid = new Grid();
            grid.RowDefinitions.Add(new RowDefinition());
            grid.RowDefinitions.Add(new RowDefinition());
            grid.ColumnDefinitions.Add(new ColumnDefinition());
            grid.ColumnDefinitions.Add(new ColumnDefinition());
    
            Label text1 = new Label();
            text1.Content = "Doc1";
            grid.Children.Add(text1);
            Grid.SetColumn(text1, 0);
            Grid.SetRow(text1, 0);
    
            Label text2 = new Label();
            text1.Content = "Doc2";
            grid.Children.Add(text2);
            Grid.SetColumn(text2, 1);
            Grid.SetRow(text2, 0);
    
            Label text3 = new Label();
            text1.Content = "Doc3";
            grid.Children.Add(text3);
            Grid.SetColumn(text3, 0);
            Grid.SetRow(text3, 1);
    
            Label text4 = new Label();
            text1.Content = "Doc4";
            grid.Children.Add(text4);
            Grid.SetColumn(text4, 1);
            Grid.SetRow(text4, 1);
    
            BlockUIContainer block = new BlockUIContainer(grid);
    
            Table table = new Table();
            TableRowGroup rg = new TableRowGroup();
            TableCell cell = new TableCell();
            cell.Blocks.Add(block);
            TableRow row = new TableRow();
            row.Cells.Add(cell);
            table.RowGroups.Add(rg);
            doc.Blocks.Add(table);
