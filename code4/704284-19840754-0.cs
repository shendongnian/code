       public void OnFragmentNavigation(FirstFloor.ModernUI.Windows.Navigation.FragmentNavigationEventArgs e)
        {
            if (this.DataContext != null)
            {
                var viewModel = this.DataContext as IContent;
                if (viewModel != null)
                {
                    viewModel.OnFragmentNavigation(e);
                }
            }
        }
        public void OnNavigatedFrom(FirstFloor.ModernUI.Windows.Navigation.NavigationEventArgs e)
        {
            if (this.DataContext != null)
            {
                var viewModel = this.DataContext as IContent;
                if (viewModel != null)
                {
                    viewModel.OnNavigatedFrom(e);
                }
            }
        }
        public void OnNavigatedTo(FirstFloor.ModernUI.Windows.Navigation.NavigationEventArgs e)
        {
            if (this.DataContext != null)
            {
                var viewModel = this.DataContext as IContent;
                if (viewModel != null)
                {
                    viewModel.OnNavigatedTo(e);
                }
            }
        }
        public void OnNavigatingFrom(FirstFloor.ModernUI.Windows.Navigation.NavigatingCancelEventArgs e)
        {
            if (this.DataContext != null)
            {
                var viewModel = this.DataContext as IContent;
                if (viewModel != null)
                {
                    viewModel.OnNavigatingFrom(e);
                }
            }
        }
