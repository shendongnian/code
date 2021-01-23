    private void hyperLinkCreateNew_Click(object sender, RoutedEventArgs e)
    {
        userControlCreateNew.Visibility = System.Windows.Visibility.Visible;
        Window parent = Window.GetWindow(this);
        LoginView loginView = (LoginView)(parent.FindName("loginControl"));
        loginView.Visibility = System.Windows.Visibility.Hidden;
    }
