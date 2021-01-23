    void RootFrame_Navigating(object sender,     NavigatingCancelEventArgs e)
    {
            if (reset && e.IsCancelable && e.Uri.OriginalString == "/MainPage.xaml")
        {
            e.Cancel = true;
            reset = false;
        }
    }
    void RootFrame_Navigated(object sender, NavigationEventArgs e)
    {
        reset = e.NavigationMode == NavigationMode.Reset;
    }
