    private void ShowPopup()
    {
        RegularContent.IsEnabled = false;
        Overlay.Visibility = Visibility.Visible;
    }
    private void ClosePopup()
    {
        RegularContent.IsEnabled = true;
        Overlay.Visibility = Visibility.Collapsed;
    }
