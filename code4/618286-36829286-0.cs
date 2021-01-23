     private byte _count;
        internal void FillbtnSubCat(Grid grid)
        {
            var myDefinition = new ColumnDefinition();
            var myButton = new Button();
            var myBlock = new TextBlock()
            {
                TextAlignment = TextAlignment.Center,
                TextWrapping = TextWrapping.Wrap,
                Text = "Some Text",
                Margin = new Thickness(5, 10, 5, 10)
            };
           
            Grid.SetColumn(myButton, _count);
            myButton.Margin = new Thickness(5, 10, 5, 25);
            myButton.MinWidth = 30;
            myButton.Content = myBlock;
            myDefinition.Width = new GridLength(68);
            grid.ColumnDefinitions.Add(myDefinition);
            grid.Children.Add(myButton);
            _count++;
        }
