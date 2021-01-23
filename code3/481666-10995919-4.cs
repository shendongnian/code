    public class MainWindowViewModel : INotifyPropertyChanged
    {
        #region Implementation of INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string e)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(e));
        }
        #endregion
        private string _myProperty;
        public string MyProperty
        {
            get { return _myProperty; }
            set
            {
                _myProperty = value;
                OnPropertyChanged("MyProperty");
            }
        }
    }
