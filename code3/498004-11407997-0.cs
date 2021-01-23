                var grid = new Grid() {
                    Name = "ObjRootGrid",
                    Background = new SolidColorBrush(Colors.Black),
                    Margin = new Thickness(248, 198, 227, 182)
                };
                var rowDef1 = new RowDefinition();
                rowDef1.Height = new GridLength(78, GridUnitType.Star);
                grid.RowDefinitions.Add(rowDef1);
                //continue adding row definitions...
                var colDef1 = new ColumnDefinition();
                colDef1.Width = new GridLength(111, GridUnitType.Star);
                grid.ColumnDefinitions.Add(colDef1);
                //continue adding column definitions...
    
                var textBox1 = new TextBlock() {
                    HorizontalAlignment = System.Windows.HorizontalAlignment.Left,
                    Margin = new Thickness(61,49,0,0),
                    TextWrapping = TextWrapping.Wrap,
                    Text = "TextBlock",
                    VerticalAlignment = System.Windows.VerticalAlignment.Top
                };
                Grid.SetColumn(textBox1, 1);
                Grid.SetRow(textBox1, 1);
                grid.Children.Add(textBox1);
                //continue adding text blocks...
