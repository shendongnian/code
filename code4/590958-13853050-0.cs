    Button button1;
    Button button2;
    void OnClick(object sender, RoutedEventArgs args)
    {
        Button button = sender as Button;
        if (button == button1)
        {
            ...
        }
        if (button == button2)
        {
            ...
        }
    }
