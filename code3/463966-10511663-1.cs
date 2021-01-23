    public class MyViewModel : INotifyPropertyChanged
    {
    
        public bool IsImageValid 
        {
            get { return _isImageValid; }
            set 
            {
                _isImageValid = value;
                OnPropertyChanged("IsImageValid");
            }
        }
    
        protected void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    
        public event PropertyChangedEventHandler PropertyChanged;
    
        private bool _isImageValid;
    }
