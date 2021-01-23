    // Navigate to Page1 FROM MainPage 
    // This can be done in a button click event
    NavigationService.Navigate(new Uri("/Page1.xaml?text=" + txtWrite.Text, UriKind.Relative));
    enter code here
    // Over OnNavigatedTo in Page1
    protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
    {
        string text;
        NavigationContext.QueryString.TryGetValue("text", out text);
        txtRead.Text = text;
    }
    
