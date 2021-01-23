    private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < 5; i++)
            {
                ComboBoxItem item = new ComboBoxItem();
                if (i == 2) item.Foreground = Brushes.Blue;
                else item.Foreground = Brushes.Pink;
                item.Content = i.ToString();
                com_ColorItems.Items.Add(item);
            }
        }
