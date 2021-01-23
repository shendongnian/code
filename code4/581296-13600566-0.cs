    protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
    {
        base.OnNavigatedTo(e);
        myAdControl.AdControlError += AdControlError;
    }
    
    private void AdControlError(object sender, ErrorEventArgs e)
    {
        string error = e.ErrorDescription;
        MessageBox.Show(error);
    }
