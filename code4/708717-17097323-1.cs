        private bool _appIdle = true;
        private void Hooks_OperationStarted(object sender, DispatcherHookEventArgs e)
        {
            ApplicationIdle = false;
        }
        private void Hooks_OperationCompleted(object sender, DispatcherHookEventArgs e)
        {
            ApplicationIdle = true;
        }
        public bool ApplicationIdle
        {
            get { return _appIdle; }
            set
            {
                _appIdle = value;
                RaisePropertyChanged("ApplicationIdle");
            }
        }
        public MainWindowViewModel()
        {
            Application.Current.Dispatcher.Hooks.OperationStarted += Hooks_OperationStarted;
            Application.Current.Dispatcher.Hooks.OperationCompleted += Hooks_OperationCompleted;
        }
