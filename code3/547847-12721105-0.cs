    public class YourViewModel : INotifyPropertyChanged {
    
        string response;
        
        public string Response {
            
            get  { return this.response; }
            
            set {
                if (this.response == value)
                    return;
                
                this.response = value;
                NotifyPropertyChanged("Response");
            }
        }
        public event NotityPropertyChangedEventHandler  = delegate {}
        
        void NotifyPropertyChanged(string propertyName) {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName);   
        }
      }
