    public class Ligne: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
    
        protected virtual void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null) 
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
    
        private string _lettrage;
        public string Lettrage
        {
            get { return _lettrage; }
            set 
            {
                _lettrage = value;
                OnPropertyChanged("Lettrage");
            }
        }
    }
