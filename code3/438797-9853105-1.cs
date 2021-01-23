    public class YourControl : Control, INotifyPropertyChanged
    {
        public string VersionNumber {
            get { return versionNumber; }
            set {
                versionNumber = value;
                NotifyPropertyChanged("VersionNumber");
            }         
        }
        private string versionNumber;
    
        public event PropertyChangedEventHandler PropertyChanged;
    
        protected void NotifyPropertyChanged(String info) {
            if (PropertyChanged != null) {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
    }
