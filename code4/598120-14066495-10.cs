    private void button1_Click(object sender, RoutedEventArgs e)
    {
        Note block = new Note() { Text = "Hello World", 
                                  Foreground = new SolidColorBrush(Colors.Blue),
                                  Background = new SolidColorBrush(Colors.PeachPuff),
                                  Height=100, Width=250 };
        gridName.Children.Add(block);
        Grid.SetColumn(block, 0);
        Grid.SetRow(block, 0);
    }
