        InternetConnectionChecker _connectionChecker = new     InternetConnectionChecker();
        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {           
            btn1.Content = _connectionChecker.ConnectingCheker();
        }
