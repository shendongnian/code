    private void but_Click(object sender, RoutedEventArgs e)
    {
        (sender as Button).IsEnabled = false;
        doSomeThing();//e.g run for more than 20 seconds
        (sender as Button).IsEnabled = true;
        FlushMouseMessages();
    }
