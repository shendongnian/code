    // Initialize the content
    UserControl1 u1 = new UserControl1();
    ContentMain.Content = u1;
    // Let's say it changes on a button click (for example)
    private void ButtonChangeContent_Click(object sender, RoutedEventArgs e)
    {
        UserControl2 u2 = new UserControl2();
        ContentMain.Content = u2;
    }
