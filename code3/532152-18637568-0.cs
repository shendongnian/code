    // Create a StackPanel and Add children
    StackPanel myStackPanel = new StackPanel();
    Border myBorder1 = new Border();
    myBorder1.Background = Brushes.SkyBlue;
    myBorder1.BorderBrush = Brushes.Black;
    myBorder1.BorderThickness = new Thickness(1);
    TextBlock txt1 = new TextBlock();
    txt1.Foreground = Brushes.Black;
    txt1.FontSize = 12;
    txt1.Text = "Stacked Item #1";
    myBorder1.Child = txt1;
    Border myBorder2 = new Border();
    myBorder2.Background = Brushes.CadetBlue;
    myBorder2.Width = 400;
    myBorder2.BorderBrush = Brushes.Black;
    myBorder2.BorderThickness = new Thickness(1);
    TextBlock txt2 = new TextBlock();
    txt2.Foreground = Brushes.Black;
    txt2.FontSize = 14;
    txt2.Text = "Stacked Item #2";
    myBorder2.Child = txt2;
    // Add the Borders to the StackPanel Children Collection
    myStackPanel.Children.Add(myBorder1);
    myStackPanel.Children.Add(myBorder2);
    mainWindow.Content = myStackPanel;
