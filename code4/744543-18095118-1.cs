For the classic "Are you sure you want to quit?" message dialog, you need to override the OnBackKeyPress event and use yourown MessageBox in it :
    protected override void OnBackKeyPress(CancelEventArgs e)
    {
        var messageBoxResult = MessageBox.Show("Are you sure you want to exit?", 
                                               "Confirm exit action",
                                               MessageBoxButton.OKCancel);
        if (messageBoxResult != MessageBoxResult.OK)
            e.Cancel = true;
        base.OnBackKeyPress(e);
    }
But I would like to point the navigation logic and why you're doing something wrong. If I understood correctly, MainPage is the first page which is shown when the app is launched and Page1 is shown when navigating to it from MainPage. 
