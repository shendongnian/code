    public class PingCommand : ICommand, INotifyPropertyChanged
    {
        private bool _canExecute;
        public bool CanExecute1
        {
            get { return _canExecute; }
            set
            {
                if (value.Equals(_canExecute)) return;
                _canExecute = value;
                CanExecuteChanged.Invoke(null, null);
                OnPropertyChanged("CanExecute1");
            }
        }
        public void Execute(object parameter)
        {
            //whatever
        }
        public bool CanExecute(object parameter)
        {
            return _canExecute;
        }
        public event EventHandler CanExecuteChanged;
        public event PropertyChangedEventHandler PropertyChanged;
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
