    public class MyViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        private string hexValue;
        public string HexValue
        {
            get
            {
                return hexValue;
            }
            set
            {
                hexValue = value;
                OnPropertyChanged("HexValue");
            }
        }
        
        
    }
