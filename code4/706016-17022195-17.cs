    class AViewModel : ViewModelBase
    {
        public AViewModel()
        {
            HelpCommand = new RelayCommand(HelpCommandExecuted, (p)=>true);
        }
        private void HelpCommandExecuted(object parameter)
        {
            var topic = parameter as string;
            if (!String.IsNullOrWhiteSpace(topic))
            {
                HelpText = String.Format("Information on the interesting topic: {0}.", topic);
            }
        }
        private string _helpText;
        public string HelpText
        {
            get { return _helpText; }
            private set
            {
                if (_helpText != value)
                {
                    _helpText = value;
                    OnPropertyChanged();
                }
            }
        }
    }
