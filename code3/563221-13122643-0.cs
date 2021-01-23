        public class MainViewModel : INotifyPropertyChanged
        { 
          private string _statusText;
          public event PropertyChangedEventHandler PropertyChanged;
          public string StatusText
          {
            get
            {
                return _statusText;
            }
            set
            {
                if (value == _statusText)
                    return;
 
                _statusText = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("StatusText"));
            }
          }
        } 
