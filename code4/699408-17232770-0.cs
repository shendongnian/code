     public void NavigateTo<TPage>(object parameter)
        {
            if (_rootFrame != null)
            {
                CoreDispatcher dispatcher = CoreApplication.MainView.CoreWindow.Dispatcher;
                dispatcher.RunAsync(CoreDispatcherPriority.Normal,
                                    () => _rootFrame.Navigate(typeof(TPage), parameter));
            }
        }
