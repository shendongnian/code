    protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
    {
        if (DecoderPrompt.IsOpen)         
        {
            e.Cancel = true;
            // Navigate to different page:
            NavigationService.Navigate(new Uri("/View/YourView.xaml", UriKind.Relative));
        }
