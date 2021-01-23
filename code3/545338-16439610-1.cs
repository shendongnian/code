        private bool _isAccessRequested;
        protected override void OnGotFocus(RoutedEventArgs e)
        {
            if (!_isAccessRequested)
            {
                _isAccessRequested = true;
                BackgroundExecutionManager.RequestAccessAsync();
            }
        }
