     private void pwd_KeyDown(object sender, KeyRoutedEventArgs e)
        { 
            if (e.Key == Windows.System.VirtualKey.Enter)
            {
                loginclick_Click(this, new RoutedEventArgs());
            }
        }
