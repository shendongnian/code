    private void AddButton_Click(object sender, RoutedEventArgs e)
    {
        lblStatus.Visibility = Visibility.Visible;
        // Validation occurs here. The UI is freezed for about 3 seconds
        CsUtil.DoEvents();
        Foo.Validate();
        lblStatus.Visibility = Visibility.Hidden;
    }
