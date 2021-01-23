     void ChangeVisibility()
     {
        if (TheBrowser._IsNavigating == false)
        {
            RefreshButton.Visibility = Visibility.Visible;
            StopButton.Visibility = Visibility.Collapsed;
        }
        else
        {
            RefreshButton.Visibility = Visibility.Collapsed;
            StopButton.Visibility = Visibility.Visible;
        }
      }
    void TheWebBrowser_Navigating(object sender,
        Microsoft.Phone.Controls.NavigatingEventArgs e)
    {
        _IsNavigating = true;
        ChangeVisibility();
    }
    void TheWebBrowser_Navigated(object sender,
        System.Windows.Navigation.NavigationEventArgs e)
    {
        _IsNavigating = false;
        ChangeVisibility();
    }
