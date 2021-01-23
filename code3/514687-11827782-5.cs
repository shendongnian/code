    private void Button_Click(object sender, RoutedEventArgs e) 
    {
        Button button = sender as Button;
        string path = null;
        if (button == button1)
        {
            path = ... // path to image file 1 here
        }
        else if ...
        if (path != null)
        {
            img1.Source = new BitmapImage(new Uri(path));
        }
    }
