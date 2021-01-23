     private void AddColumn()
        {
            //Create the columndefinition with a width of "3*"
            ColumnDefinition column = new ColumnDefinition();
            column.Width = new GridLength(3, GridUnitType.Star);
            //Add the column to the grid
            MainGrid.ColumnDefinitions.Add(column);
            //Create the rectangle
            Rectangle rect = new Rectangle();
            rect.Fill = new SolidColorBrush(Colors.Beige);
            MainGrid.Children.Add(rect);
            Grid.SetColumn(rect, 3);
            //Create the label
            Label label = new Label();
            label.VerticalAlignment = System.Windows.VerticalAlignment.Center;
            label.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
            label.Content = "P4";
            MainGrid.Children.Add(label);
            Grid.SetColumn(label, 3);
        }
