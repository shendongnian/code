    // assuming ExternalProgramsWindowData are your bitmap objects
    public class SourceList : ObservableCollection<ExternalProgramsWindowData> {
    }
    public class ViewModel : INotifyPropertyChanged {
        private SourceList mySourceList;
        public SourceList MySourceList {
             get { return mySourceList; }
             set {
                 mySourceList = value;
                 FirePropertyChanged("MySourceList");
                 }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void FirePropertyChanged (string propertyName) {
            if (PropertyChanged != null) {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
