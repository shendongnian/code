        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            // Index of last column
            int lastColumn = TargetGrid.ColumnDefinitions.Count - 1;
            // Iterate all child elements
            foreach (UIElement uiElement in TargetGrid.Children.ToList())
            {
                // See if the element is a Textbox
                TextBlock textBlock = uiElement as TextBlock;
                if (textBlock != null)
                {
                    // if the textbox contains "?"
                    if (textBlock.Text == "?")
                    {
                        // Get column of textbox
                        int row = (int)textBlock.GetValue(Grid.RowProperty);
                        
                        // Add a new control in the last column (same row)
                        var newTextBox = new TextBox();
                        newTextBox.SetValue(Grid.RowProperty, row);
                        newTextBox.SetValue(Grid.ColumnProperty, lastColumn);
                        newTextBox.Text = string.Format("I am a new Textbox in row {0}, col {1}", row, lastColumn);
                        TargetGrid.Children.Add(newTextBox);
                    }
                }
            }
        }
