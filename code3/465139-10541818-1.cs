        // Navigate to Page1 FROM MainPage 
        // This can be done in a button click event
        NavigationService.Navigate(new Uri("/Page1.xaml?text=" + txtWrite.Text, UriKind.Relative));
    
    // Override OnNavigatedTo in Page1.xaml.cs
    protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
    {
        string text;
        NavigationContext.QueryString.TryGetValue("text", out text);
        txtRead.Text = text;
    }
    
