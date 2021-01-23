    public class Data : INotifyPropertyChanged
    {
        private ObservableCollection<Item> _results;
        public ObservableCollection<Item> Results 
        {  
            get { return _results; }
            set
            {
                _results = value;
                RaisePropertyChanged("Data"); 
            }
        }
    
        // ...
    
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string prop)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }
        #endregion
    }
