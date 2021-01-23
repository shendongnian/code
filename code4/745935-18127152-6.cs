    public class ViewModel : INotifyPropertyChanged
    {
        private readonly Command _command;
        public Command Command
        {
            get { return _command; }
        }
        public ViewModel()
        {
            _command = new Command(this);
        }
        private string _textBoxOnUserControlOne;
        private string _textBoxOnUserControlTwo;
        public string TextBoxOnUserControlOne
        {
            get { return _textBoxOnUserControlOne; }
            set
            {
                if (value == _textBoxOnUserControlOne) return;
                _textBoxOnUserControlOne = value;
                OnPropertyChanged("TextBoxOnUserControlOne");
            }
        }
        public string TextBoxOnUserControlTwo
        {
            get { return _textBoxOnUserControlTwo; }
            set
            {
                if (value == _textBoxOnUserControlTwo) return;
                _textBoxOnUserControlTwo = value;
                OnPropertyChanged("TextBoxOnUserControlTwo");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
