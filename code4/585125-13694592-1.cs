    public class GridData : INotifyPropertyChanged
    {
        private ObservableCollection<PersonName> _results;
        public ObservableCollection<PersonName> Results 
        {  
            get { return _results; }
            set
            {
                _results = value;
                RaisePropertyChanged("GridData");
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
