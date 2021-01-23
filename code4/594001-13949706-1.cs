    protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            if (App.ViewModel.bName != null)
            {
                myButton.Content = App.ViewModel.bName;
                myButton.Name = App.ViewModel.bID;
            }
 
            base.OnNavigatedTo(e);
        }
