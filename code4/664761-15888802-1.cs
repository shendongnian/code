    class ViewModelClass
    {
        public ViewModelClass
        {
            this.RefreshCommand = new RelayCommand(() =>
            {
                NavigationService.Navigate(new Uri(NavigationService.Source + "?Refresh=true", UriKind.Relative));
            }   
        }
    
        public RelayCommand RefreshCommand { get; set;}
    
    }
