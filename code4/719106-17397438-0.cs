    while (Frame.BackStackDepth > 0)
    {
        if (Frame.CanGoBack)
        {
            Frame.GoBack();
        }
    }
    Frame.CacheSize = 0;
    Frame.Navigate(typeof(LoginScreen));
