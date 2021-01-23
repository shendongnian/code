    public class MovieViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string _movieTitle;
        
        public string MovieTitle
        {
            get { return _movieTitle; }
            set
            {
                if (_movieTitle == value)
                    return;
                _movieTitle = value;
                OnPropertyChanged();
            }
        }
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
