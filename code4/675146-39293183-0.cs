        public MainViewModel()
        {
            QuitCommand = new RelayCommand(ExecuteQuitCommand);
        }
        public RelayCommand QuitCommand { get; private set; }
        private void ExecuteQuitCommand() 
        {
            Messenger.Default.Send<CloseMessage>(new CloseMessage());
        }
