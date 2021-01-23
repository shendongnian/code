    protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
            {
                if (e.NavigationMode == NavigationMode.Back)
                    ViewModelLocator.ClearDetailsViewModel();
    
                base.OnNavigatingFrom(e);
            }
